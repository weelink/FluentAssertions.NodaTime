# LocalDateTimeAssertions.NotHaveNanosecondsWithinSecond method

Asserts that the current LocalDateTime does not have the specified nanoseconds within the second.

```csharp
public AndConstraint<LocalDateTimeAssertions> NotHaveNanosecondsWithinSecond(
    int nanosecondOfSecond, string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| nanosecondOfSecond | The nanoseconds within the second that the current LocalDateTime is not expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;LocalDateTimeAssertions&gt; which can be used to chain assertions.

## See Also

* class [LocalDateTimeAssertions](../LocalDateTimeAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->
