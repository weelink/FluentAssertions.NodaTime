# OffsetDateAssertions.HaveDate method

Asserts that the current OffsetDate has the specified OffsetDate.

```csharp
public AndWhichConstraint<OffsetDateAssertions, LocalDate> HaveDate(LocalDate date, 
    string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| date | The OffsetDate that the current OffsetDateTime is expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndWhichConstraint&lt;OffsetDateTimeAssertions, OffsetDate&gt; which can be used to assert the OffsetDate.

## See Also

* class [OffsetDateAssertions](../OffsetDateAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->