# ZonedDateTimeAssertions.BeInCalendar method

Asserts that the current ZonedDateTime has the specified CalendarSystem.

```csharp
public AndWhichConstraint<ZonedDateTimeAssertions, CalendarSystem> BeInCalendar(
    CalendarSystem calendar, string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| calendar | The CalendarSystem that the current ZonedDateTime is expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndWhichConstraint&lt;ZonedDateTimeAssertions, CalendarSystem&gt; which can be used to assert the CalendarSystem.

## See Also

* class [ZonedDateTimeAssertions](../ZonedDateTimeAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->
