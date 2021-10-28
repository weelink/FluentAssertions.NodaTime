# OffsetDateTimeAssertions.HaveNanosecondsWithinDay method

Asserts that the current OffsetDateTime has the specified nanoseconds within the day.

```csharp
public AndConstraint<OffsetDateTimeAssertions> HaveNanosecondsWithinDay(long nanosecondOfDay, 
    string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| nanosecondOfDay | The nanoseconds within the day that the current OffsetDateTime is expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;OffsetDateTimeAssertions&gt; which can be used to chain assertions.

## See Also

* class [OffsetDateTimeAssertions](../OffsetDateTimeAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->