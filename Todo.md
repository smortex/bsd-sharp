# [Mono:FreeBSD](http://www.mono-project.com/Mono:FreeBSD) page #

The BSD# page on the Mono website (http://www.mono-project.com/Mono:FreeBSD) is outdated.

I (romain) used the contact form to have some pointers in ~ december 2008 but did not have an answer.



# BROKEN Ports #

The following ports are known to fail with the current infrastructure:

  * deskutils/beagle (upstream does not support gmime2-sharp-2.4)


# Fix linuxisms #

The following projects are known to rely on linuxisms that may have to be worked around a better may and for witch patches have to be send upstream:

| **port**                 | **linuxism**    | **status** |
|:-------------------------|:----------------|:-----------|
| audio/last-exit        | PrctlLinuxism | TODO |
| deskutils/giver        | PrctlLinuxism | TODO |
| deskutils/tasque       | PrctlLinuxism | TODO |
| deskutils/tomboy-devel | PrctlLinuxism | TODO |

# Check ports #

The `portlint` utility (`ports-mgmt/portlint`) can detect problems in ports. All BSD# ports have to be verified with this tool.

# Build ports with NOPORTDOCS defined #

... and fix accordingly.