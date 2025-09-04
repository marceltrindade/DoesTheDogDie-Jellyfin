# Jellyfin Plugin: Does The Dog Die? Integration

[![GitHub](https://img.shields.io/github/license/marceltrindade/DoesTheDogDie-Jellyfin)](https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/blob/main/LICENSE)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/marceltrindade/DoesTheDogDie-Jellyfin)](https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/releases)

This plugin integrates [Does The Dog Die?](https://www.doesthedogdie.com/) (DDD) into your Jellyfin media server. It automatically scans your movie library, queries the DDD API for content warnings (triggers), and applies a tag (`DTDD-Bloqueado`) to movies that match user-defined sensitive topics. This allows you to use Jellyfin's Parental Control features to hide these movies from specific user profiles.

## Features

- Automatically scans your Jellyfin movie library.
- Queries the Does The Dog Die? API for content triggers.
- Configurable list of triggers to block.
- Applies a custom tag (`DTDD-Bloqueado`) to movies with matching triggers.
- Integrates seamlessly with Jellyfin's Parental Control system.
- Runs as a scheduled task (daily by default).

## Prerequisites

- A Jellyfin server (tested with version 10.9.x).
- A [Does The Dog Die? API Key](https://www.doesthedogdie.com/keys). This is free and easy to obtain.

## Installation

1. Download the latest `.tar.gz` file from the [Releases](https://github.com/your_username/jellyfin-plugin-ddtd-integration/releases) page.
2. On your Jellyfin server, navigate to the plugins directory. This is typically located at:
    - **Linux/macOS**: `/var/lib/jellyfin/plugins/` or `~/.local/share/jellyfin/plugins/`
    - **Windows**: `C:\ProgramData\Jellyfin\Server\plugins\`
3. Create a new folder named `DoesTheDogDie` inside the plugins directory.
4. Extract the contents of the downloaded `.tar.gz` file into this new folder.
5. Restart your Jellyfin server.
6. The plugin should now appear in your Jellyfin dashboard under `Plugins`.

## Configuration

1. In the Jellyfin dashboard, go to `Plugins` and find "Does the Dog Die Integration".
2. Click on the plugin to access its settings.
3. Enter your **Does The Dog Die? API Key**.
4. In the "Triggers" field, enter a list of topics you want to block, one per line.
    - Example:
      ```
      sexual assault
      animal cruelty
      suicide
      ```
    - You can find a full list of possible triggers on the DDD website or by exploring the API.
5. Save the configuration.
6. The plugin will automatically run its scan daily at 2 AM. You can also trigger it manually from the Jellyfin dashboard under `Scheduled Tasks`.

## Using Parental Controls

To hide the tagged movies from a specific user:

1. Go to `Dashboard` > `Users`.
2. Select the user profile (e.g., "Wife").
3. Go to the `Parental Control` section.
4. Under `Access Schedule`, you can set time limits if desired.
5. Under `Content`, find the `Blocked Tags` section.
6. Add the tag `DTDD-Bloqueado`.
7. Save the changes.

Movies tagged with `DTDD-Bloqueado` will now be hidden from this user's view.

## Development

This plugin is built using .NET 8.0.

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor (e.g., Visual Studio Code, Visual Studio)

### Building the Plugin

1. Clone this repository.
2. Navigate to the `DoesTheDogDie` directory.
3. Run `dotnet build` to build the project.
4. Run `dotnet publish -c Release -o bin` to create a release build.

The compiled files will be located in the `bin` directory.

### Creating a Release Package

A build script is included to create a release package:

1. Make sure you have `tar` installed on your system.
2. Run `./build.sh` from the project root directory.
3. The release package will be created in the `releases` directory.

### Contributing

Contributions are welcome! Please read `CONTRIBUTING.md` for details on our code of conduct and the process for submitting pull requests.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Acknowledgments

- Thanks to the [Jellyfin](https://jellyfin.org/) project for the excellent media server.
- Thanks to [Does The Dog Die?](https://www.doesthedogdie.com/) for providing the valuable content warnings API.

---

*This README was automatically generated for version 1.0.0 of the plugin.*