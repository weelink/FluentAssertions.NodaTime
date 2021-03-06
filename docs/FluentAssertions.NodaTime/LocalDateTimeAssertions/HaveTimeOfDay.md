# LocalDateTimeAssertions.HaveTimeOfDay method

Asserts that the current LocalDateTime has the specified LocalTime.

```csharp
public AndWhichConstraint<LocalDateTimeAssertions, LocalTime> HaveTimeOfDay(LocalTime timeOfDay, 
    string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| timeOfDay | The LocalTime that the current LocalDateTime is expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndWhichConstraint&lt;LocalDateTimeAssertions, LocalTime&gt; which can be used to assert the LocalTime.

## See Also

* class [LocalDateTimeAssertions](../LocalDateTimeAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->
