[api documentation](api/InventorCode.AddinPack.md) | [readme](../README.md)

---

# Contributions

## Dependencies

This library targets .Net Framework 4.8, and requires the following nuget packages for build:
- [DefaultDocumentation](https://www.nuget.org/packages/DefaultDocumentation)

Documentation is build via the [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation) nuget package.  This runs during builds. Documentation is generated as markdown files and stored in the [docs](docs/) folder.

## Build and Deploy

There are a few powershell scripts to help with build and deployment.

- `update-version.ps1`
    - updates the version numbers in the source code based on the Conventional Commits used in the git history
    - to mark the package as a pre-release, this can be executed while in a branch other than main
- `build.ps1`
    - removes old nuget packages from the artifacts directory
    - builds the project, including
        - build library
        - package nuget
        - (generate documentation)
- `deploy.ps1`
    - deploys the nuget package to the nuget feed

### Version Numbers

Versioning will follow [Sematic Versioning](https://semver.org/) once version 2.0.0 is released. The version numbers will follow the format `MAJOR.MINOR.PATCH` where:

* MAJOR - incompatible API changes
* MINOR - added functionality in a backwards compatible manner
* PATCH - backwards compatible bug fixes

### Branch Guidance

*main* will be the main repository branch; this branch will contain the most up-to-date code.  All short-lived branches will be merged back into *main* after a code review by repo maintainers.

Releases will be tagged and nuget builds pushed to our package source.

The following branch names are typical examples of short-lived branch names...

* feature/xx
* bugfix/xx
* issue/xx
* username/xx

### Commit Guidelines

[Conventional Commits](https://www.conventionalcommits.org/en) will be used as the commit message guidelines.  Following these simple guidelines will ensure commit message consistency that simplifies changelog generation and version number management.  Contributors are encouraged to visit the page and read the tutorial and spec.  Pull requests are expected to follow this convention.

A simple, breezy tutorial follows... commit messages should be in the form "KEYWORD: message".  Commit may have multiple lines. Try to keep each commit to a single keyword.  This keyword is one of the following:

- build
- chore
- ci
- docs
- feat
- fix
- refactor
- revert
- style
- test

Breaking changes in the codebase are denoted by an exclamation mark after a keyword, such as:

- feat!
- fix!
- etc...

A footer ```BREAKING CHANGE:``` should also be included in the commit message for human readability, but is not strictly required.
