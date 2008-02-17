#!/bin/sh
#-
# Copyright (c) 2002-2004 FreeBSD GNOME Team <freebsd-gnome@FreeBSD.org>
# All rights reserved.
#
# Redistribution and use in source and binary forms, with or without
# modification, are permitted provided that the following conditions
# are met:
# 1. Redistributions of source code must retain the above copyright
#    notice, this list of conditions and the following disclaimer.
# 2. Redistributions in binary form must reproduce the above copyright
#    notice, this list of conditions and the following disclaimer in the
#    documentation and/or other materials provided with the distribution.
#
# THIS SOFTWARE IS PROVIDED BY THE AUTHOR AND CONTRIBUTORS ``AS IS'' AND
# ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
# IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
# ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR OR CONTRIBUTORS BE LIABLE
# FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
# DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
# OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
# HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
# LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
# OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
# SUCH DAMAGE.
#
# $Id: mono-merge.sh,v 1.11 2005/05/31 01:40:26 mezz7 Exp $
#

# These variables are overrideable in /usr/local/etc/${SCRIPTNAME}.cfg.

SRCDIR=${MARCUSMERGE_SRCDIR:=""}
			# The path to the BSD# ports without the trailing
			# module name (i.e. without the trailing /FreeBSD-ports)
DESTDIR=${MARCUSMERGE_DESTDIR:="/usr/ports"}
			# The path to the official ports collection.
VERBOSE=${MARCUSMERGE_VERBOSE:="no"}
			# If you want verbose output.
SUPFILE=${MARCUSMERGE_SUPFILE:=""}
			# The path your ports-supfile (default: auto).
TARBALL=${MARCUSMERGE_TARBALL:="no"}
			# Set to yes to download a tarball instead of using CVS.
MODULE=${MARCUSMERGE_PORTS:="FreeBSD-ports"}
			# CVS module to checkout.

# You do not have to change anything beyond this line.

PKGVERSION_CMD="/usr/sbin/pkg_version"
PKGVERSION_ARGS="-l \<"

CVSUP_CMD="/usr/local/bin/cvsup -g"
FETCH_CMD="/usr/bin/fetch"
FETCH_ARGS="-4 -q"

update_main="no"
pkgversion="no"
updating="no"
show_updating="no"
use_monodev="no"
use_monosvn="no"

# End list of overrideable variables

SCRIPTNAME=`basename $0`

if [ -f /usr/local/etc/${SCRIPTNAME}.cfg ]; then
.    /usr/local/etc/${SCRIPTNAME}.cfg
elif [ -f /usr/local/etc/`echo ${SCRIPTNAME} | sed -e 's/.sh$//'`.cfg ]; then
.    /usr/local/etc/`echo ${SCRIPTNAME} | sed -e 's/.sh$//'`.cfg
fi

SCRIPTNAME=`basename $0`

CVSROOT=":ext:anonymous@forgecvs1.novell.com:/cvsroot/bsd-sharp"
TARBALL_URL="http://forge.novell.com/modules/xfmod/cvs/cvsbrowse.php/bsd-sharp/${MODULE}"
RMPORTS="RMPORTS"
MCVER_FILE="MCVER"

MCVER="2005051901"

get_tmpfile()
{
    template=$1
    tmpfile=""

    if [ -n "${MC_TMPDIR}" -a -d "${MC_TMPDIR}" ]; then
	tmpfile="${MC_TMPDIR}/${template}.XXXXXX"
    elif [ -n "${TMPDIR}" -a -d "${TMPDIR}" ]; then
	tmpfile="${TMPDIR}/${template}.XXXXXX"
    elif [ -d "/var/tmp" ]; then
	tmpfile="/var/tmp/${template}.XXXXXX"
    elif [ -d "/tmp" ]; then
	tmpfile="/tmp/${template}.XXXXXX"
    elif [ -d "/usr/tmp" ]; then
	tmpfile="/usr/tmp/${template}.XXXXXX"
    else
	return 1
    fi

    tmpfile=`mktemp -q ${tmpfile}`

    echo ${tmpfile}

    return 0
}

download_tarball()
{
    tmpfile=`get_tmpfile mctmp`

    if [ $? != 0 ]; then
	printf "Unable to create a temporary file for the downloaded tarball.\nPlease set your MC_TMPDIR environment variable to a suitable temporary directory,\nand run this script again.\n"
	exit 1
    fi

    echo "===> Downloading the tarball for the ${MODULE} module."
    ${FETCH_CMD} ${FETCH_ARGS} -o ${tmpfile} "${TARBALL_URL}/${MODULE}.tar.gz?tarball=1"
    if [ $? != 0 ]; then
        printf "Failed to download ${MODULE}.tar.gz from ${TARBALL_URL}.\n\n"
        exit 1
    fi
    echo "===> Download done."
    echo "===> Extracting ${tmpfile} to ${SRCDIR}."
    mkdir -p ${SRCDIR}
    tar -C ${SRCDIR} -xvjf ${tmpfile}
    echo "===> Extraction done."
    rm -f ${tmpfile}
}

args=`getopt ulpaxUDSs:d:c:m: $*`

if [ $? != 0 ]; then
    echo "usage: ${SCRIPTNAME} [-s <directory>] [-d <directory>] [-c <cvsroot>] [-m <module>] [-t] [-u] [-v] [-l] [-p] [-a] [-x] [-U] [-D|-S]"
    exit 1
fi

set -- $args

for i; do
    case "$i" in
	-s)
		SRCDIR="$2"; shift;
		shift;;
	-d)
		DESTDIR="$2"; shift;
		shift;;
	-c)
		CVSROOT="$2"; shift;
		shift;;
	-m)
		MODULE="$2"; shift;
		shift;;
	-v)
		VERBOSE="yes";
		shift;;
	-t)
		TARBALL="yes";
		shift;;
	-u)
		updating="yes";
		shift;;
	-l)
		pkgversion="yes";
		shift;;
	-p)
		update_main="yes";
		shift;;
	-a)
		updating="yes";
		pkgversion="yes";
		update_main="yes";
		shift;;
	-x)
		experimental="yes";
		shift;;
	-U)
		show_updating="yes";
		shift;;
	-D)
		use_monodev="yes";
		shift;;
	-S)
		use_monosvn="yes";
		shift;;
	--)
		shift; break;;
    esac
done

if [ -z "${SRCDIR}" ]; then
    echo "You did not specify a SRCDIR; aborting..."
    exit 1
fi

if [ -z "${MODULE}" ]; then
    echo "You did not specify a MODULE; aborting..."
    exit 1
fi

if [ ${use_monodev} = "yes" -a ${use_monosvn} = "yes" ]; then
    echo "Please select mono-devel or mono-svn but not both."
    exit 1
fi

# This function does, well, everything. It takes the module name as an argument.
run_marcusmerge() {
moduledir="$1"
if [ ${SRCDIR} = ${DESTDIR} -o "${SRCDIR}/${moduledir}" = ${DESTDIR} ]; then
    printf "Your SRCDIR is set to the same path as your DESTDIR.\nPlease set it to a path where we can store the BSD# ports.\n\n"
    exit 1
fi

first_time=0

if [ "${TARBALL}" != "yes" ]; then
    printf "First we have to check out the ${moduledir} module from\nhttp://forge.novell.com/modules/xfmod/project/?bsd-sharp\n\nCVS Password: anonymous\n\n"
fi

# If the SRCDIR doesn't exist, we need to download the repo.  Currently, we
# can do this via CVS or from a tarball generated periodically.
if [ ! -d ${SRCDIR} -o ! -d ${SRCDIR}/${moduledir} ]; then
    first_time=1
    if [ "${TARBALL}" = "yes" ]; then
        download_tarball
    else
        echo "===> Checking out the ${moduledir} module."
        mkdir -p ${SRCDIR}
        cd ${SRCDIR}
	cvs -z3 -d${CVSROOT} checkout -P ${TAG} ${moduledir}
	if [ $? != 0 ]; then
	    printf "Failed to check out the BSD# ports tree.\n\n"
	    exit 1
	fi
        echo "===> Checkout done."
    fi
fi

# Update the BSD# repo if so requested. Don't update if we just checked
# out (or downloaded) the repo for this first time.
if [ ${updating} = "yes" -a ${first_time} = 0 ]; then
    echo "===> Updating the BSD# ports tree"
    if [ "${TARBALL}" = "yes" ]; then
	rm -rf "${SRCDIR}/${moduledir}"
        download_tarball
    else
        cd "${SRCDIR}/${moduledir}"
        cvs -z3 update -Pd -A
	if [ $? != 0 ]; then
	    printf "Failed to update the BSD# ports tree.\n\n"
	    exit 1
	fi
    fi
    echo "===> Updating done."
fi

# Determine if this repo needs a newer mono-merge.
mcver="0"
if [ -f "${SRCDIR}/${moduledir}/${MCVER_FILE}" ]; then
    mcver=`cat "${SRCDIR}/${moduledir}/${MCVER_FILE}"`
    if [ "${mcver}" != "${MCVER}" ]; then
        echo "This repository requires a newer version of mono-merge.  Please go to http://forge.novell.com/modules/xfmod/project/?bsd-sharp to download the latest version." | fmt 75 79
        exit 1
    fi
fi

# Handle ports that may have been moved or deleted in the BSD# repo.
if [ -f "${SRCDIR}/${moduledir}/${RMPORTS}" ]; then
    echo "===> Removing obsolete ports from main tree"
    for i in `cat ${SRCDIR}/${moduledir}/${RMPORTS} | cut -d '|' -f1`; do
	if [ "${VERBOSE}" = "yes" ]; then
	    echo " Removing obsolete port ${i}"
	fi
	rm -rf ${DESTDIR}/${i}
    done
    if [ "${VERBOSE}" = "yes" ]; then
	echo "Adding removed ports to MOVED"
    fi
    date=`date "+%Y-%m-%d"`
    cat ${SRCDIR}/${moduledir}/${RMPORTS} | sed -e "s|%%DATE%%|${date}|g" \
    	>> ${DESTDIR}/MOVED
    echo "===> done."
fi

echo "===> Merging files into the ports directory"
echo "${SRCDIR}/${moduledir} --> ${DESTDIR}"

if [ -d ${SRCDIR}/${moduledir}/Mk ]; then
    if [ "${VERBOSE}" = "yes" ]; then
	echo "Merging Mk files"
    fi
    if [ ! -d ${DESTDIR}/Mk ]; then
	if [ "${VERBOSE}" = "yes" ]; then
	    echo "Creating nonexistent destination category directory: Mk"
	fi
	mkdir -p ${DESTDIR}/Mk
    fi
    for mk in `ls -1 ${SRCDIR}/${moduledir}/Mk/*.mk`; do
	cp ${mk} ${DESTDIR}/Mk
    done
fi

for category in `ls -1 ${SRCDIR}/${moduledir}`; do
    if [ ${category} = "CVS" ]; then
	continue
    fi
    for port in `ls -1 ${SRCDIR}/${moduledir}/${category}`; do
	if [ ${port} = "CVS" ]; then
	    continue
	fi
	if [ ! -f ${SRCDIR}/${moduledir}/${category}/${port}/Makefile ]; then
	    continue
	fi
	if [ ! -d ${DESTDIR}/${category} ]; then
	    if [ "${VERBOSE}" = "yes" ]; then
		echo "Creating nonexistent destination category directory: ${category}"
            fi
	    mkdir -p ${DESTDIR}/${category}
	fi
	if [ -d ${DESTDIR}/${category}/${port} ]; then
	    if [ "${VERBOSE}" = "yes" ]; then
		echo "Removing old directory for: ${category}/${port}"
	    fi
	    rm -rf ${DESTDIR}/${category}/${port}
	fi

	cd ${SRCDIR}/${moduledir}/${category}
	tar --exclude *CVS* -cf - ${port} | \
		tar -xf - -C ${DESTDIR}/${category}
    done
done
}	# end of run_marcusmerge()

# Try to get our cvsup supfile if we will be updating the main ports tree.
if [ ${update_main} = "yes" ]; then
    if [ -z "${SUPFILE}" ]; then
	SUPFILE=`cd ${DESTDIR} && make -V PORTSSUPFILE`
    fi
    if [ -z "${SUPFILE}" ]; then
        printf "Update of main ports tree requested but you forgot\nto set SUPFILE in this script; aborting...\n\n"
        exit 1
    fi
    if [ ! -f ${SUPFILE} ]; then
        printf "Update of main ports tree requested but I could not\nfind SUPFILE: ${SUPFILE}; aborting...\n\n"
        exit 1
    fi
fi

# Update the main ports tree if so requested.
if [ ${update_main} = "yes" ]; then
    echo "===> Updating the main ports tree"
    if [ ${VERBOSE} = "yes" ]; then
        ${CVSUP_CMD} ${SUPFILE}
    else
        ${CVSUP_CMD} ${SUPFILE} -L0
    fi
    if [ $? != 0 ]; then
	printf "Failed to cvsup the ports tree.\n\n"
	exit 1
    fi
    echo "===> Updating done."
fi

run_marcusmerge ${MODULE}
if [ "${experimental}" = "yes" ]; then
	run_marcusmerge ${EXPMODULE}
fi

echo "===> Merging done."; echo

if [ ${use_monodev} = "yes" ]; then
    if [ ! -f "${SRCDIR}/${MODULE}/lang/mono-devel/Makefile" ]; then
        echo "===> WARNING: mono-devel doesn't exist, fallback to mono"; echo
        use_monodev="no"
    fi
fi

if [ ${use_monosvn} = "yes" ]; then
    if [ ! -f "${SRCDIR}/${MODULE}/lang/mono-svn/Makefile" ]; then
        echo "===> WARNING: mono-svn doesn't exist, fallback to mono"; echo
        use_monosvn"no"
    fi
fi

if [ ${use_monodev} = "yes" ]; then
    for _port in `cat ${SRCDIR}/${MODULE}/PORTSLIST`; do
        if [ -f ${DESTDIR}/${_port}/Makefile ]; then
            sed -i.bak 's|${PORTSDIR}/lang/mono$|${PORTSDIR}/lang/mono-devel|g' \
                ${DESTDIR}/${_port}/Makefile
	    sed -i.bak 's|${PORTSDIR}/lang/mono \$|${PORTSDIR}/lang/mono-devel|g' \
	    	${DESTDIR}/${_port}/Makefile
            sed -i.bak 's|${PORTSDIR}/lang/mono-svn$|${PORTSDIR}/lang/mono-devel|g' \
                ${DESTDIR}/${_port}/Makefile
	    sed -i.bak 's|${PORTSDIR}/lang/mono-svn$|${PORTSDIR}/lang/mono-devel|g' \
	    	${DESTDIR}/${_port}/Makefile
            rm ${DESTDIR}/${_port}/Makefile.bak
        fi
    done
    echo "===> setting mono dependency to lang/mono-devel done."; echo

elif [ ${use_monosvn} = "yes" ]; then
    for _port in `cat ${SRCDIR}/${MODULE}/PORTSLIST`; do
        if [ -f ${DESTDIR}/${_port}/Makefile ]; then
	    sed -i.bak 's|${PORTSDIR}/lang/mono$|${PORTSDIR}/lang/mono-svn|g' \
	        ${DESTDIR}/${_port}/Makefile
	    sed -i.bak 's|${PORTSDIR}/lang/mono \$|${PORTSDIR}/lang/mono-svn|g' \
	    	${DESTDIR}/${_port}/Makefile
	    sed -i.bak 's|${PORTSDIR}/lang/mono-devel$|${PORTSDIR}/lang/mono-svn|g' \
	        ${DESTDIR}/${_port}/Makefile
	    sed -i.bak 's|${PORTSDIR}/lang/mono-devel \$|${PORTSDIR}/lang/mono-svn|g' \
	    	${DESTDIR}/${_port}/Makefile
	    rm ${DESTDIR}/${_port}/Makefile.bak
        fi
    done
    echo "===> setting mono dependency to lang/mono-svn done."; echo

else
    for _port in `cat ${SRCDIR}/${MODULE}/PORTSLIST`; do
        if [ -f ${DESTDIR}/${_port}/Makefile ]; then
            sed -i.bak 's|${PORTSDIR}/lang/mono-svn$|${PORTSDIR}/lang/mono|g' \
                ${DESTDIR}/${_port}/Makefile
            sed -i.bak 's|${PORTSDIR}/lang/mono-devel$|${PORTSDIR}/lang/mono|g' \
                ${DESTDIR}/${_port}/Makefile
            rm ${DESTDIR}/${_port}/Makefile.bak
        fi
    done
    echo "===> setting mono dependency to lang/mono done."; echo
fi

if [ "${pkgversion}" = "yes" ]; then
    echo "===> Listing outdated ports..."
    ${PKGVERSION_CMD} ${PKGVERSION_ARGS}
    echo "===> Listing done."
fi

echo ""

if [ "${show_updating}" = "yes" ]; then
    less ${SRCDIR}/${MODULE}/UPDATING
fi

echo ""

echo "Merge finished, please follow your regular updating procedures" | /usr/bin/fmt 75 79
