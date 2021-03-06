# LocalTimeAssertions.HaveMillisecond method

Asserts that the current LocalTime has the specified millisecond.

```csharp
public AndConstraint<LocalTimeAssertions> HaveMillisecond(int millisecond, string because = "", 
    params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| millisecond | The millisecond that the current LocalTime is expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;LocalTimeAssertions&gt; which can be used to chain assertions.

## See Also

* class [LocalTimeAssertions](../LocalTimeAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->
