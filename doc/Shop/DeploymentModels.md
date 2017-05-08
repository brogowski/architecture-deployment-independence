# Deployment Models

When deploying `Shop` example we need to investigate 2 axis of deployment:

- Communication
- Resources (storage) 

## Communication deployment options

- In single process
- In separate processes (single machine)
- In separate "machines" (containers, virtual machines etc.)

## Storage deployment options

- Storage per component
- Shared storage for all components

## Models table

Storage\Communication | Single Process      | Separate Processes | Separate Machines  |
:--------------------:|:-------------------:|:------------------:|:------------------:|
Shared storage        | Maximum performance |                    |                    |
Storage per component |                     |                    | Maximum resilience |