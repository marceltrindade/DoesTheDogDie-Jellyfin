# Jellyfin Plugin: Does The Dog Die? Integration

[![GitHub](https://img.shields.io/github/license/marceltrindade/DoesTheDogDie-Jellyfin)](https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/blob/main/LICENSE)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/marceltrindade/DoesTheDogDie-Jellyfin)](https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/releases)

This plugin integrates [Does The Dog Die?](https://www.doesthedogdie.com/) (DDD) into your Jellyfin media server. It automatically scans your movie library, queries the DDD API for content warnings (triggers), and applies a tag (`DTDD-Bloqueado`) to movies that match user-defined sensitive topics. This allows you to use Jellyfin's Parental Control features to hide these movies from specific user profiles.

## Why I Created This Plugin

As a parent, I've always been concerned about the content my children have access to at home. While Jellyfin is an excellent solution for managing our home media library, there was a gap in automated tools for filtering content with sensitive triggers that could be disturbing for children or people recovering from trauma.

I discovered [Does The Dog Die?](https://www.doesthedogdie.com/) while researching information about how to handle specific scenes in movies that could affect my family. The site offers an impressive database of "triggers" for movies and TV shows, including:

- Violence
- Sexual assault
- Animal cruelty
- Suicide themes
- Specific phobias
- And many others

Although Jellyfin has an excellent parental control system, it relies on manual metadata and tagging to filter content. This means someone needs to manually review each movie and apply the appropriate tags. With a growing media library, this becomes impractical.

I identified that Does The Dog Die? has an API that could be used to automate this process. The idea was to create a plugin that:

1. Automatically scans your Jellyfin movie library
2. Queries the Does The Dog Die? API for each movie (using the IMDb ID)
3. Identifies user-configurable triggers
4. Automatically applies tags to movies that contain those triggers
5. Seamlessly integrates with Jellyfin's existing parental control system

By making this plugin open source, I hope to benefit:

1. **Families** who want to filter sensitive content for children
2. **People in recovery** from trauma who need to avoid certain triggers
3. **Individuals with specific phobias** who want to avoid disturbing content
4. **The Jellyfin community** as a whole, expanding the ecosystem's capabilities

This project also represents my contribution to the open source movement. Jellyfin is an excellent example of what can be achieved with collaboratively developed quality software. By creating this plugin, I hope to:

1. Demonstrate how easy it is to extend Jellyfin's functionality
2. Encourage other developers to create their own plugins
3. Improve the Jellyfin experience for users with specific content filtering needs

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
    - **Windows**: `C:\ProgramData\Jellyfin\Server\plugins`
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