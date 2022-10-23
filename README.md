# Design Patterns 

## Singleton Design Pattern 
It is a pattern that requires that an object instance is generated only once and its instance is always used.It aims to use the instance value of a target object in the same way when it is changed by many users. One of the biggest goals is to check the state of an object.When passing an object instance, especially between layers, this design pattern is used if this object is just processing and does not hold a certain value.

For example, in the Business layer, the Manager object performs the operations in it as a method. If there are a thousand users, each of them makes a request, and it gets new again. Since we are producing an object to process and we want everyone to use it, then we need to produce this object once and make it available to everyone.

When should we not use it? When we produce an object with a singleton, this object remains in memory. When we produce a singleton manager object in an ASP.Net application, this object does not disappear until we restart the ISS. Therefore, we must determine whether everyone will use the same object.

At the same time, we should not create an object as a singleton in case of a one-time use. Because the object lifetime must expire when the process ends. It takes up memory space.

In environments where Multi Thread is working, if two users want an object at the same time and that object has not been created yet, we can lock this object and perform the operation after the job is finished. We produce the object with the Lock operation.

## Factory Method Design Pattern

## Abstrack Factory Design Pattern 

## Prototype Design 

## Builder Design 

## Fecade Design 

## Adapter Design 

## Composite Design 

## Proxy Design 

## Decorator Design 

## Bridge Design 
