# Unity 3D Flying Game 🚀

A 3D flying game built with Unity 6.0 LTS featuring smooth flight controls and browser-compatible WebGL deployment.

## 🎮 Game Features

- **Smooth Flight Controls** - Intuitive WASD movement with Q/E turning
- **3D Flight Physics** - Forward/backward and strafe movement in 3D space
- **Browser Compatible** - WebGL build ready for web deployment
- **Beginner Friendly** - Clean, well-commented code for learning
- **Open Source** - MIT licensed for modification and learning

## 🕹️ Controls

| Key | Action |
|-----|--------|
| **W** | Move Forward |
| **S** | Move Backward |
| **A** | Strafe Left |
| **D** | Strafe Right |
| **Q** | Turn Left |
| **E** | Turn Right |

## 🚀 How to Play

### Option 1: Play in Browser (Coming Soon)
*WebGL build will be hosted online for instant play*

### Option 2: Run in Unity Editor
1. **Prerequisites:**
   - Unity 6.0 LTS or newer
   - Git installed on your system

2. **Clone and Run:**
   ```bash
   git clone https://github.com/affigabmag/unity-flying-game.git
   cd unity-flying-game
   ```

3. **Open in Unity:**
   - Open Unity Hub
   - Click "Add project from disk"
   - Select the `unity-flying-game` folder
   - Click "Open"

4. **Play:**
   - Press the Play button (▶️) in Unity Editor
   - Use WASD + Q/E keys to fly around

## 🛠️ Development

### Built With
- **Unity 6.0 LTS** (6000.0.54f1)
- **Universal Render Pipeline (URP)**
- **C# Scripting**
- **Visual Studio 2022**

### Project Structure
```
Assets/
├── PlayerController.cs     # Main flight control script
├── Scenes/
│   └── SampleScene.unity  # Main game scene
└── Settings/              # URP and project settings

ProjectSettings/           # Unity project configuration
Packages/                 # Package dependencies
```

### Key Components

#### PlayerController.cs
The main script handling flight mechanics:
- **Movement System** - Transform-based movement for smooth flight
- **Input Handling** - WASD for movement, Q/E for turning
- **Speed Control** - Configurable speed and rotation parameters

#### Scene Setup
- **Player Object** - Capsule collider with visual indicator cube
- **Camera** - Standard third-person follow setup
- **Lighting** - Directional light for basic scene illumination

## 🔧 Customization

### Adjusting Flight Speed
Edit values in `PlayerController.cs`:
```csharp
public float speed = 10f;           // Movement speed
public float rotationSpeed = 500f;  // Turning speed
```

### Adding Features
The codebase is designed for easy expansion:
- Add terrain and obstacles
- Implement speed boosts
- Create "around the world" mechanics
- Add UI/HUD elements
- Include sound effects

## 🌐 WebGL Build

### Building for Web
1. **Switch Platform:**
   - File → Build Settings
   - Select "WebGL"
   - Click "Switch Platform"

2. **Build:**
   - Click "Build"
   - Choose output folder
   - Wait for compilation

3. **Deploy:**
   - Upload generated files to web server
   - Ensure server supports WebGL compression (.br files)

### Server Requirements
- **Static File Server** (nginx, apache, or simple HTTP server)
- **MIME Type Support** for .br, .js, .wasm files
- **HTTPS** recommended for full compatibility

## 📋 System Requirements

### For Unity Development
- **OS:** Windows 10/11, macOS, or Linux
- **Unity:** 6.0 LTS or newer
- **RAM:** 4GB minimum, 8GB recommended
- **Storage:** 2GB for Unity + project files

### For WebGL Playback
- **Browser:** Chrome, Firefox, Safari, Edge (recent versions)
- **WebGL Support** enabled
- **JavaScript** enabled

## 🤝 Contributing

Contributions are welcome! Here's how to help:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Commit** your changes (`git commit -m 'Add amazing feature'`)
4. **Push** to the branch (`git push origin feature/amazing-feature`)
5. **Open** a Pull Request

### Contribution Ideas
- Add new flight mechanics (barrel rolls, speed boosts)
- Create terrain and world environments
- Implement UI/menu systems
- Add sound effects and music
- Create mobile touch controls
- Optimize performance

## 📝
