# Zup Utilites
A wide varity of tools made for unity game development.

## Extensions
do i really need to specify what it does?
### Vector 3
#### Offset
offsets the Vector3 and returns the new one.
```cs
    Vector3 vector = Vector3.Right
    // Returns {1,0,0}

    vector.Offset(-1,5,0)
    // Returns {0,5,0}
```
#### Override
overrides the Vector3 and retunrs the new one.
```cs
    Vector3 vector = Vector3.Right
    // Returns {1,0,0}

    vector.Offset(-1,5,0)
    // Returns {-1,5,0}
```

## Tweakables
easy way to create fields accessabile for non programing editors. will become a custom attribute down the road.

## Required Attribute
mark any field with [RequiredAttribute] will show on inspector and hierarchy if you failed to provide references