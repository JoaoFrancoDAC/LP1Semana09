# AnimalKingdom Project

## Class Diagram

```mermaid

classDiagram
    class Animal {
        <<abstract>>
        +Sound() string
    }
    
    class IMammal {
        <<interface>>
        +NumberOfNipples int
    }
    
    class ICanFly {
        <<interface>>
        +NumberOfWings int
    }
    
    class Dog {
        +NumberOfNipples int
        +Sound() string
    }
    
    class Cat {
        +NumberOfNipples int
        +Sound() string
    }
    
    class Bat {
        +NumberOfNipples int
        +NumberOfWings int
        +Sound() string
    }
    
    class Bee {
        +NumberOfWings int
        +Sound() string
    }
    
    Animal <|-- Dog
    Animal <|-- Cat
    Animal <|-- Bat
    Animal <|-- Bee
    IMammal <|.. Dog
    IMammal <|.. Cat
    IMammal <|.. Bat
    ICanFly <|.. Bat
    ICanFly <|.. Bee
