# Creational patterns
Deal with object creation
Abstract the object instanttiation process
Help make your system independent of how its objects are created, composed and represented

Five patterns: 
	- Abstract factory, builder, factory method, prototype, singleton

# Structural patterns:
Deal with ways to define relations between classes or objects
Concerned with how classes and objects are composed to form larger structures

Seven patterns:
	- Adapter, Bridge, Composite, Decorator, Facade, Flyweight, Proxy

# Behavioural patterns:
Deal with ways to communicate between classes or objects
Characterize complex control flow that is difficult to follow at runtime
Let you concentrate on the way objects are interconnected

Eleven patterns:
	- Chain of Responsibility, Command, Interpreter, Iterator, Mediator, Memento, Observer, State,
	  Strategy, Template Method, Visitor

# Object Oriented Principles
Two important object oriented principles are followed by the gang of four in their design patterns.

	1) Program to an interface, not an implementation
Clients remain unaware of the specific types of objects they use
Clients remain unaware of the classes that implement these objects, they only know the interface
Can also be implemented with the abstract class language feature, in general:
	* use an abstract base class when you need to provide some basic functionality that can potentially be overriden, 
	  eg: can declare some default functionality that is usable or overridable by all subclasses
	* use an interface when you only need to specify the expected functionality of a class

Commonly correlates to adhering to the open/closed principle (SOLID)

	2) Favor object composition over class inheritance
Concern reusing functionality

		- Class inheritance (white-box reuse):
Let's you define the implementation of one class in terms of another's
You create a subclass of a base or parent class (inherit the parent class)

		- Object composition (black-box reuse):
New functionality is obtained by assembling or composing objects to get more complex functionality
Internal details of objects are not visible to the composing class
Commonly relates to the single responsibility principle (SOLID)
	- A class should have one and only one reason to change