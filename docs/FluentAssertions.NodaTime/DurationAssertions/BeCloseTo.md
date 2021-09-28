# DurationAssertions.BeCloseTo method (1 of 2)

Asserts that this Duration is within *precision* of *other*.

```csharp
public AndConstraint<DurationAssertions> BeCloseTo(Duration other, Duration precision, 
    string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| other | The Duration to compare to. |
| precision | The maximum amount of time which the two values may differ. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;DurationAssertions&gt; which can be used to chain assertions.

## See Also

* class [DurationAssertions](../DurationAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

---

# DurationAssertions.BeCloseTo method (2 of 2)

Asserts that this Duration is within *precision* of *other*.

```csharp
public AndConstraint<DurationAssertions> BeCloseTo(Duration other, TimeSpan precision, 
    string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| other | The Duration to compare to. |
| precision | The maximum amount of time which the two values may differ. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;DurationAssertions&gt; which can be used to chain assertions.

## See Also

* class [DurationAssertions](../DurationAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->