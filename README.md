# RespawnToggle

Main purpose is to be able to stop respawn waves of NTF/CI teams

## Minimum requirements
[EXILED](https://github.com/ExMod-Team/EXILED) **9.0.0+**

## How to install
Put **RespawnToggle.dll** inside `%appdata%\EXILED\Plugins` if you're on **Windows** or `~/.config/EXILED/Plugins` on **Linux**.

### Configs
```yaml
respawn_toggle:
  # Indicates whether the plugin is enabled or not
  is_enabled: true
  debug: false
```

### Usage
Requires RespawnEvents vanilla permission

Read current status of respawn waves is allowed or not.

Usage: `rw s` or `respawnwaves status`.

Toggle respawning of all waves: `rw t`

