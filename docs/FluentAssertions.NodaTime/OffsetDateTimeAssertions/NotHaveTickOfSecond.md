# OffsetDateTimeAssertions.NotHaveTickOfSecond method

Asserts that the current OffsetDateTime does not have the specified tick of second.

```csharp
public AndConstraint<OffsetDateTimeAssertions> NotHaveTickOfSecond(int tickOfSecond, 
    string because = "", params object[] becauseArgs)
```

| parameter | description |
| --- | --- |
| tickOfSecond | The tick of second that the current OffsetDateTime is not expected to have. |
| because | A formatted phrase as is supported by Object[]) explaining why the assertion is needed. If the phrase does not start with the word because, it is prepended automatically. |
| becauseArgs | Zero or more objects to format using the placeholders in *because*. |

## Return Value

An AndConstraint&lt;OffsetDateTimeAssertions&gt; which can be used to chain assertions.

## See Also

* class [OffsetDateTimeAssertions](../OffsetDateTimeAssertions.md)
* namespace [FluentAssertions.NodaTime](../../FluentAssertions.NodaTime.md)

<!-- DO NOT EDIT: generated by xmldocmd for FluentAssertions.NodaTime.dll -->