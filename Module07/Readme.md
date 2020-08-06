## Tasks  
**Objective:** 
- *understand delegate usage scenarios;*
- *understand the relationship delegates versus interfaces;*
- *understand callback functions;*
- *study design pattern Strategy;*
- *study design pattern Observer;*
- *understand difference between events and delegates;*
- *understand DRY (DonвЂ™t Repeat Yourself), SoC (Separation of Concerns principles), Low Coupling principles;*
- *understand standard event delegate pattern.*

**Tasks**
1. Create a console application.
2. Create a class, which allows to bubble-sort a matrix of integers (do not use System.Array methods) in order to arrange matrix rows:
- *in ascending (descending) order of sums of matrix row elements*
- *in ascending (descending) order of maximum element in a matrix row;*
- *in ascending (descending) order of minimum element in a matrix row;*
- *USE DELEGATES with STRATEGY PATTERN (comparison type and order type should be passed by user. You can hardcode demo-matrix)*
3. Develop a Countdown class, which implements the capability to transmit a message to any subscriber who subscribes to the event after the appointed time (waiting time is provided by the user).
You can use the Thread.Sleep() method to create a wait effect. Provide the possibility of subscribing to an event in several classes.
