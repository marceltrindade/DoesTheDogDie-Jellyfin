#!/bin/bash

# Script para build e empacotamento do plugin DoesTheDogDie para Jellyfin

echo "Building DoesTheDogDie plugin for Jellyfin..."

# Navegar para o diretório do plugin
cd /home/marcel/projetos/jellyfin-plugin-ddtd-integration/DoesTheDogDie

# Compilar o plugin
echo "Compiling plugin..."
dotnet publish -c Release -o bin

# Verificar se a compilação foi bem-sucedida
if [ $? -ne 0 ]; then
    echo "Build failed!"
    exit 1
fi

# Criar pasta temporária para empacotamento
PLUGIN_NAME="DoesTheDogDie"
PLUGIN_VERSION="1.0.1"
TEMP_DIR="/tmp/${PLUGIN_NAME}_${PLUGIN_VERSION}"
mkdir -p "$TEMP_DIR"

# Copiar arquivos necessários para a pasta temporária
echo "Copying files..."
cp bin/${PLUGIN_NAME}.dll "$TEMP_DIR/"
cp bin/meta.json "$TEMP_DIR/"

# Criar arquivo tar.gz do plugin
echo "Creating plugin package..."
cd /tmp
tar -czf "/home/marcel/projetos/jellyfin-plugin-ddtd-integration/releases/${PLUGIN_NAME}_${PLUGIN_VERSION}.tar.gz" "${PLUGIN_NAME}_${PLUGIN_VERSION}"

# Limpar pasta temporária
rm -rf "$TEMP_DIR"

echo "Plugin package created successfully!"
echo "Package location: /home/marcel/projetos/jellyfin-plugin-ddtd-integration/releases/${PLUGIN_NAME}_${PLUGIN_VERSION}.tar.gz"