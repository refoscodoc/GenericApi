# GenericApi

This template provides an API microservice with main logic, persistance split into class libraries.
MediatR is used for the decoupling, and Mapper is used for mapping the DTOs to the actual models. 

The Domain layer should be intended to be a CoreLibrary common to all the microservices in the solution. Basically:

<img src="https://freeimage.host/i/y21nkP" alt="Structure" title="Structure Tree">

Very basic stuff but I have seen it in many corporate, real-life applications and not so often in tutorials or GitHub material.

It's a down to earth project which took no more than an hour to complete, hence don't expect fireworks. It's intended to be the base for the app design.
