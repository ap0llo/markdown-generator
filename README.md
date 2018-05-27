# MarkdownGenerator

## Usage

*TODO*

## Building from source

*TODO*

## Versioning and Branching

The version of the library is automatically derived from git and the information in `version.json` using
[Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning):

- The master branch  always contains the latest version. Packages produced from master are always
  marked as pre-relase versions (using the `-prerelease` suffix).
- Stable versions are built from release branches. Build from release branches will have no `-prerelease` suffix
- Builds from any other branch will have both the `-prerelease` and the git commit hash included
  in the version string

The `Set-Version.ps1` script can be used to create a new release branch and update the version on *master*. 
The script will:

- read `version.json` to determine the current version of the branch (typically *master*)
- create a new release branch for version, e.g. *release/v1.0*
- Remove the pre-release tag from `version.json` on the release branch
- Increment the version on *master* so builds from that branch will produce pre-release packages
  for the next version. The next version is either the next major or minor version,
  depending on the parameters passed to `Set-Version.ps1` (either `-Major` or `-Minor`)
