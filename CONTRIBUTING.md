# Contributing to Jellyfin Plugin: Does The Dog Die? Integration

First off, thank you for considering contributing to this project! It's people like you that make the open-source community such a fantastic place to learn, inspire, and create.

The following is a set of guidelines for contributing to this plugin. These are mostly guidelines, not rules. Use your best judgment, and feel free to propose changes to this document in a pull request.

## How Can I Contribute?

### Reporting Bugs

This section guides you through submitting a bug report. Following these guidelines helps maintainers and the community understand your report, reproduce the behavior, and find related reports.

- **Use a clear and descriptive title** for the issue to identify the problem.
- **Describe the exact steps which reproduce the problem** in as many details as possible.
- **Provide specific examples to demonstrate the steps**.
- **Describe the behavior you observed after following the steps** and point out what exactly is the problem with that behavior.
- **Explain which behavior you expected to see instead and why.**
- **Include screenshots and animated GIFs** if possible, as they help demonstrate the problem.

### Suggesting Enhancements

This section guides you through submitting an enhancement suggestion, including completely new features and minor improvements to existing functionality.

- **Use a clear and descriptive title** for the issue to identify the suggestion.
- **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
- **Provide specific examples to demonstrate the steps**.
- **Describe the current behavior and explain which behavior you expected to see instead** and why.
- **Explain why this enhancement would be useful** to most users.

### Pull Requests

- Fill in the required template
- Do not include issue numbers in the PR title
- Include screenshots and animated GIFs in your pull request whenever possible.
- Follow the [C# Style Guide](https://docs.microsoft.com/en-us/dotnet/csharp/) and [Jellyfin's coding conventions](https://github.com/jellyfin/jellyfin/blob/master/.editorconfig).
- End all files with a newline
- Avoid platform-dependent code

## Styleguides

### Git Commit Messages

- Use the present tense ("Add feature" not "Added feature")
- Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit the first line to 72 characters or less
- Reference issues and pull requests liberally after the first line

### C# Style Guide

All C# code must adhere to the [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) and the style defined in the `.editorconfig` file.

## Additional Notes

### Issue and Pull Request Labels

This section lists the labels we use to help organize and identify issues and pull requests.

- `bug`: Something isn't working
- `enhancement`: New feature or request
- `documentation`: Improvements or additions to documentation
- `good first issue`: Good for newcomers
- `help wanted`: Extra attention is needed

## Publishing New Releases

To publish a new release of the plugin, follow these steps:

1. **Update version numbers**:
   - Update the version in `DoesTheDogDie/meta.json`
   - Update the version in `CHANGELOG.md`

2. **Commit and push changes**:
   ```bash
   git add DoesTheDogDie/meta.json CHANGELOG.md
   git commit -m "Bump version to X.X.X"
   git push
   ```

3. **Create and push a new tag**:
   ```bash
   git tag -a vX.X.X -m "Release version X.X.X"
   git push origin vX.X.X
   ```

4. **Build the release package**:
   ```bash
   chmod +x build.sh
   ./build.sh
   ```

5. **Create a GitHub Release**:
   - Go to https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/releases
   - Click "Draft a new release"
   - Select the new tag
   - Add release notes from the CHANGELOG
   - Upload the package from `releases/DoesTheDogDie_X.X.X.tar.gz`
   - Publish the release

## Submitting to Official Jellyfin Plugin Repository

To add this plugin to the official Jellyfin plugin repository:

1. **Prepare the plugin**:
   - Ensure the code is stable and well-documented
   - Verify all metadata is correct in `meta.json`
   - Confirm the plugin works as expected

2. **Create a plugin icon**:
   - Create a 512x512 PNG image
   - Name it `poster.png`
   - Add it to the repository

3. **Generate package checksum**:
   ```bash
   sha256sum releases/DoesTheDogDie_X.X.X.tar.gz
   ```

4. **Fork the manifest repository**:
   - Go to https://github.com/jellyfin/jellyfin-plugin-manifest
   - Click "Fork"

5. **Clone your fork**:
   ```bash
   git clone https://github.com/marceltrindade/jellyfin-plugin-manifest.git
   cd jellyfin-plugin-manifest
   ```

6. **Add the plugin to the manifest**:
   - Edit the appropriate manifest file (usually `manifest.json`)
   - Add an entry with the plugin details

7. **Commit and push**:
   ```bash
   git add manifest.json
   git commit -m "Add DoesTheDogDie plugin"
   git push
   ```

8. **Create a Pull Request**:
   - Go to your fork on GitHub
   - Click "New Pull Request"
   - Fill in the required information
   - Submit the PR

Thank you for reading and happy coding!