# AGENTS.md

## Project
This is a Unity 6 C# game project.

## Important folders
- Gameplay code: Assets/Scripts
- Unity settings: ProjectSettings
- Packages: Packages

## Safety rules
- Do not edit Library, Temp, obj, Logs, Build, Builds.
- Do not edit .unity, .prefab, .asset, .meta files unless explicitly requested.
- Prefer small focused changes.
- Before editing, explain the plan.
- Preserve serialized fields in MonoBehaviour scripts.
- Do not rename public or [SerializeField] fields without warning, because Unity references can break.
- Do not create giant manager classes.
- Prefer separate MonoBehaviours, services, ScriptableObject configs, events, and interfaces.
- After code changes, explain what must be assigned in the Unity Inspector.

## Unity rules
- Use UnityEngine only where needed.
- Do not use async/threads for Unity API calls.
- Avoid expensive FindObjectOfType in Update.
- Avoid logic in Update unless required.
- Use Debug.Log only for temporary diagnostics and mark it clearly.

## Git rules
- Before big changes, recommend creating a new branch.
- Do not commit automatically unless asked.
