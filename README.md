# Portfolio

# Unity Framework – Strukturprojekt

Dieses Repository enthält ein persönliches Lern- und Strukturprojekt, das ich im Rahmen meiner Beschäftigung mit Programmierung in **C#** und der **Unity Engine** entwickelt habe.

Die Idee dahinter war, ein wiederverwendbares Grundgerüst zu erstellen, das es mir erlaubt, neue Projektideen schneller aufzusetzen und dabei von Anfang an eine klare und nachvollziehbare Struktur im Code zu behalten.

Der Fokus liegt dabei nicht auf einem fertigen Spiel, sondern auf der Organisation von Programmcode, Zuständigkeiten von Skripten und einer kontrollierten Initialisierung von Systemen.

---

## Grundidee

Beim Arbeiten mit Unity ist mir aufgefallen, dass in vielen Projekten schnell eine unübersichtliche Struktur entstehen kann. Besonders wenn Skripte voneinander abhängen oder in einer bestimmten Reihenfolge geladen werden müssen.

Aus diesem Grund habe ich versucht, ein kleines Framework zu entwickeln, das:

- eine klare Modulstruktur vorgibt  
- eine kontrollierte Initialisierung von Systemen ermöglicht  
- Skripte nach klaren Aufgabenbereichen trennt  
- die Wartbarkeit und Lesbarkeit des Codes verbessert  

---

## Modulstruktur

Das Projekt ist in zwei grundlegende Module unterteilt.

---

### InitialModule

Das **InitialModule** enthält grundlegende Systeme, die unabhängig von einer bestimmten Szene oder einem Level benötigt werden und vor dem Erscheinen des Hauptmenüs des Spiels initialisiert werden.

**Beispiele**

- Szenenverwaltung  
- globale Manager  
- allgemeine Referenzen  
- grundlegende Systeminitialisierung  

Nach Abschluss des Ladeprozesses stehen diese anschließend anderen Systemen zur Verfügung.

---

### GameModule

Das **GameModule** enthält dagegen Skripte, die nur für die aktuell laufende Spielumgebung benötigt werden.

**Beispiele**

- Spielerlogik  
- Interaktionen  
- Kamerasteuerung  
- Gameplaybezogene Systeme  

Diese greifen auf die zuvor geladenen Basisstrukturen zu.

---

## Bootstrap-System

Um sicherzustellen, dass alle Systeme in der richtigen Reihenfolge geladen werden, habe ich Bootstrap-Skripte eingeführt.

Diese sorgen dafür, dass:

1. zuerst grundlegende Systeme geladen werden  
2. im weiteren Verlauf die spielbezogenen Systeme gestartet werden  

Damit wird verhindert, dass Skripte auf Referenzen zugreifen, die noch nicht initialisiert wurden.

---

## Skriptrollen

Um die Struktur übersichtlich zu halten, habe ich die Skripte in drei Rollen unterteilt.

---

### System

System-Skripte enthalten hauptsächlich Logik und Abläufe.

Sie steuern beispielsweise:

- Bewegungslogik  
- Interaktionen  
- Animationen  
- allgemeine Spielmechaniken  

---

### Manager

Manager dienen hauptsächlich als zentrale Datenhalter und Referenzpunkte.  
Sie bündeln wichtige Referenzen und stellen diese anderen Systemen zur Verfügung.

---

### Registry / Datenklassen

Diese Klassen dienen dazu, Datenstrukturen und Konfigurationen zu verwalten, zum Beispiel in Form von:

- Listen  
- Arrays  
- ScriptableObjects  

Dadurch lassen sich Daten vom eigentlichen Programmcode trennen.

---

## Ziel dieses Projekts

Dieses Projekt ist Teil meines persönlichen Lernprozesses im Bereich Softwareentwicklung.

Es soll verdeutlichen, dass ich mich mit grundlegenden Konzepten wie

- modularer Codeorganisation  
- Systemtrennung  
- Initialisierungsreihenfolgen  
- Wartbarkeit von Projekten  

praktisch auseinandersetze.

Mein Ziel ist es, durch die Auseinandersetzung mit technischen Problemen und Herausforderungen meine strukturierte Analysefähigkeit zu schulen und meine fachlichen Kenntnisse zu erweitern. Außerdem möchte ich diese Grundlagen vertiefen, um neue Lösungsstrategien entwickeln zu können.
