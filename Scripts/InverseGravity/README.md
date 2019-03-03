# Inverse Gravity

Umkehrung der Schwerkraft mit optionalem Orbiting um vorgegebenen Punkt.

Beispielkonfiguration:

- Parent
    - Objekt
    - Standort

Parent erhält Script, Objekt wird InvertedObjekt in Skript zugewiesen.
Standort ist ein Transform-Objekt, was CenterPoint zugewiesen werden soll, wenn Orbiting aktiv ist.

# GravityToggle

Umschaltung der Schwerkraft für einzelne GameObjects.

Properties:

* AllowToggle : bool -> Gibt an, ob die Schwerkraft mehrfach oder einmalig umgeschaltet werden kann
* GravityInverseInitial : bool -> Gibt an, ob das GameObject als Initialwert bereits inverse Gravitation besitzt
* ToggleKey : KeyCode -> Key der zum Umschalten verwendet wird. Default: Space