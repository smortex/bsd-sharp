#!/usr/bin/perl

# Tool to aid in the merging of BSD# ports into the ports tree.
# - script taken from the Marcuscom FreeBSD Gnome CVS repo.
#
# $MCom: portstools/merge_gnome.pl,v 1.9 2005/10/29 21:57:42 marcus Exp $

use strict;
use Getopt::Std;
use vars qw($PATCHFILE $CVSLOG $MC_DIR $PORTSDIR $EXCLUDE_FILE);

$PATCHFILE    = '/usr/local/src/BSDSHARP/patch/bsd-sharp.patch';
$CVSLOG       = '/usr/local/src/BSDSHARP/patch/cvs.log';
$MC_DIR       = '/usr/local/src/BSDSHARP/FreeBSD-ports';
$PORTSDIR     = $ENV{'PORTSDIR'} || '/usr/local/src/FREEBSD/ports';
$EXCLUDE_FILE = undef;

my $opts = {};
getopts('x:', $opts);

if ($opts->{'x'}) {
        $EXCLUDE_FILE = $opts->{'x'};
}

chdir $MC_DIR || die "Cannot change directory to $MC_DIR: $!\n";
unlink $PATCHFILE;
system("touch $PATCHFILE");

opendir(DIR, ".");

my @categories = readdir(DIR);

closedir(DIR);

my @excludes;
if (defined($EXCLUDE_FILE)) {
        if (open(EXCLUDE, $EXCLUDE_FILE)) {
                @excludes = <EXCLUDE>;
                close(EXCLUDE);
        } else {
                warn
                    "Unable to open exclude file $EXCLUDE_FILE for reading: $!\n";
        }
}

my (@old, @new, @ports, @newports);
foreach my $category (@categories) {
        next if ($category =~ /^\./);
        next if (!-d $category);
        next if ($category eq "CVS");

        opendir(DIR, $category);

        my @gnome_ports = readdir(DIR);

        closedir(DIR);

        foreach my $port (@gnome_ports) {
                next if ($port =~ /^\./);
                next if (!-d "$category/$port");
                next if ($port eq "CVS");
                my $tmpport = $port;
                $tmpport =~ s/\+/\\+/g;
                next if (grep /^$category\/$tmpport$/, @excludes);

                if (!-d "$PORTSDIR/$category/$port") {
                        push @newports, "$category/$port";
                        next;
                }

                my @results =
                    `diff --exclude *CVS* --exclude *.orig --exclude *.rej --brief -r $PORTSDIR/$category/$port $category/$port`;
                foreach (@results) {
                        if (/^Only in ([^:]+): (.+)/) {
                                my $loc  = $1;
                                my $file = $2;
                                if ($loc =~ m|$PORTSDIR|) {
                                        $loc =~ s|${PORTSDIR}/||;
                                        push @old, "$loc/$file"
                                            if ($file !~ /\.(orig|rej)$/);
                                } else {
                                        if ($file !~ /\.(orig|rej)$/) {
                                                push @new, "$loc/$file";
                                                if (-d "$loc/$file") {
                                                        opendir(DIR,
                                                                "$loc/$file");

                                                        my @nfiles =
                                                            readdir(DIR);

                                                        closedir(DIR);

                                                        foreach
                                                            my $nfile (@nfiles)
                                                        {

                                                                next
                                                                    if ($nfile
                                                                        =~ /^\./
                                                                    );
                                                                next
                                                                    if ($nfile
                                                                        eq
                                                                        "CVS");
                                                                push @new,
                                                                    "$loc/$file/$nfile"
                                                                    if ($nfile
                                                                        !~ /\.(orig|rej)$/
                                                                    );
                                                        }
                                                }
                                        }

                                }
                        }
                }

                system(
                        "diff --exclude *CVS* --exclude *.orig --exclude *.rej -ruN $PORTSDIR/$category/$port $category/$port >> $PATCHFILE"
                );
		unlink "/usr/local/src/BSDSHARP/patch/$category-$port.patch";

		system("touch /usr/local/src/BSDSHARP/patch/$category-$port.patch");
		system(
			"diff --exclude *CVS* --exclude *.orig --exclude *.rej -ruN $PORTSDIR/$category/$port $category/$port >> /usr/local/src/BSDSHARP/patch/$category-$port.patch"
		);

                push @ports, "$category/$port";
        }
}

unless (open(LOG, ">$CVSLOG")) {
        die "Unable to open $CVSLOG for writing: $!\n";
}

print LOG "#!/bin/sh\n\n";

foreach (@newports) {
        print LOG "# NEW PORT: $_\n";
}

my $portslist = join(" ", @ports);
print LOG "#rm -rf ",     $portslist, "\n";
print LOG "cvs up -PAd ", $portslist, "\n";
print LOG "patch -p < $PATCHFILE\n";

foreach (sort @new) {
        if ($_ !~ /^\.\#/) {
                print LOG "cvs add $_\n";
        }
}

foreach (sort { $b cmp $a } @old) {
        print LOG "cvs rm -f $_\n";
}

print LOG "cvs commit ", $portslist, "\n";

close(LOG);
