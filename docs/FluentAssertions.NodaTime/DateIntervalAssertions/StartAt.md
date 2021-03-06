# DateIntervalAssertions.StartAt method

Asserts that the current DateInterval starts at *localDate*.

```csharp
public AndConstraint<DateIntervalAssertions> StartAt(LocalDate? localDate, string because = "", 
    params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| localDate | The inclusive lower bound of the interval. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepstarted automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;DateIntervalAssertions&gt; which can be used to chain assertions.

## See Also

* class [DateIntervalAssertions](../DateIntervalAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->
