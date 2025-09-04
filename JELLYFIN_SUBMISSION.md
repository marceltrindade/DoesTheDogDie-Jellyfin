# Informações para Submissão ao Repositório Oficial do Jellyfin

Este documento contém todas as informações necessárias para submeter o plugin "Does the Dog Die Integration" ao repositório oficial de plugins do Jellyfin.

## Informações do Plugin

- **Nome**: Does the Dog Die Integration
- **Descrição**: Integrates Does The Dog Die? content warnings into Jellyfin for parental control filtering.
- **Visão Geral**: Applies tags to movies with content triggers from Does The Dog Die? for use with parental controls.
- **Autor**: marceltrindade
- **Categoria**: General
- **GUID**: 0b881525-a8f2-416b-9b3b-10ab164cd3c8
- **URL do Projeto**: https://github.com/marceltrindade/DoesTheDogDie-Jellyfin

## Informações da Versão

- **Versão**: 1.0.2
- **Changelog**: 
  - Section in README.md explaining why the plugin was created
  - JELLYFIN_SUBMISSION.md with detailed instructions for submitting to official Jellyfin plugin repository
  - Plugin icon (poster.png) in PNG format for Jellyfin plugin repository
  - Enhanced documentation and contribution guidelines
- **Target ABI**: 10.9.0.0
- **URL de Download**: https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/releases/download/v1.0.2/DoesTheDogDie_1.0.2.tar.gz
- **Checksum (SHA256)**: 41a8f1a860782e9f32836ee47a922b08b376f8a7dba7da7e78f68099a655a568
- **Timestamp**: 2025-09-04T00:00:00Z
- **URL da Imagem**: https://raw.githubusercontent.com/marceltrindade/DoesTheDogDie-Jellyfin/main/DoesTheDogDie/poster.png

## Entrada para o Manifesto do Jellyfin

```json
{
  "name": "Does the Dog Die Integration",
  "description": "Integrates Does The Dog Die? content warnings into Jellyfin for parental control filtering.",
  "overview": "Applies tags to movies with content triggers from Does The Dog Die? for use with parental controls.",
  "owner": "marceltrindade",
  "category": "General",
  "guid": "0b881525-a8f2-416b-9b3b-10ab164cd3c8",
  "imageUrl": "https://raw.githubusercontent.com/marceltrindade/DoesTheDogDie-Jellyfin/main/DoesTheDogDie/poster.png",
  "versions": [
    {
      "version": "1.0.2",
      "changelog": "Section in README.md explaining why the plugin was created. JELLYFIN_SUBMISSION.md with detailed instructions for submitting to official Jellyfin plugin repository. Plugin icon (poster.png) in PNG format for Jellyfin plugin repository. Enhanced documentation and contribution guidelines.",
      "targetAbi": "10.9.0.0",
      "sourceUrl": "https://github.com/marceltrindade/DoesTheDogDie-Jellyfin/releases/download/v1.0.2/DoesTheDogDie_1.0.2.tar.gz",
      "checksum": "41a8f1a860782e9f32836ee47a922b08b376f8a7dba7da7e78f68099a655a568",
      "timestamp": "2025-09-04T00:00:00Z"
    }
  ]
}
```

## Instruções para Submissão

1. Faça um fork do repositório jellyfin-plugin-manifest:
   - Acesse https://github.com/jellyfin/jellyfin-plugin-manifest
   - Clique em "Fork"

2. Clone seu fork localmente:
   ```bash
   git clone https://github.com/marceltrindade/jellyfin-plugin-manifest.git
   cd jellyfin-plugin-manifest
   ```

3. Adicione o plugin ao manifesto:
   - Edite o arquivo `manifest.json`
   - Adicione a entrada JSON acima

4. Faça commit e push:
   ```bash
   git add manifest.json
   git commit -m "Add DoesTheDogDie plugin"
   git push
   ```

5. Crie um Pull Request:
   - Vá para o seu fork no GitHub
   - Clique em "New Pull Request"
   - Preencha as informações necessárias
   - Envie o PR

Com essas informações, o processo de submissão ao repositório oficial do Jellyfin será facilitado.