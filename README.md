# RespawnToggle

Main purpose is to be able to stop respawn waves of NTF/CI teams

## Minimum requirements
[EXILED](https://github.com/Exiled-Team/EXILED) **8.0.1++**

## How to install
Put **RespawnToggle.dll** inside `%appdata%\EXILED\Plugins` if you're on **Windows** or `~/.config/EXILED/Plugins` on **Linux**.

### Configs
```yaml
respawn_toggle:
  # Indicates whether the plugin is enabled or not
  is_enabled: true
  debug: false
  # Keep wave status between round change
  keep_state_on_next_round: false
```

### Usage
Read current status of respawn waves is allowed or not.
Requires `respawntoggle.read` permission
Usage: `rw s` or `respawnwaves status`.

Toggle respawning:
Requires `respawntoggle.write` permission
Usage: `rw t all/ntf/ci` or `respawnwaves toggle all/ntf/ci`
For all teams use: `rw t all`
For NTF team use: `rw t ntf`
For CI team use: `rw t ci`

### Permissions
`respawntoggle.read`
`respawntoggle.write`

To grant all permissions use `respawntoggle.*`
