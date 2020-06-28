# Throw.If

Guard clause .NET library.

Supports C# 8.0 [nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references).

## Use

```c#
using ThrowIf;
using ThrowIf.Exceptions;

Throw<ArgumentNullExceptionFactory>
    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeNull)
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull);

Throw<ValidationExceptionFactory>
    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeEmpty)
    .If(condition: guid.Value.ToString().StartsWith("A"), name: nameof(guid), messageTemplate: CanNotStartsWithCharA)
    .If(condition: text.IsEmpty(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeEmpty)
    .If(condition: text.Length > 10, message: $"{nameof(text.Length)} is not valid")
    .If(condition: text.Length < 100, messageTemplate: () => $"{nameof(text.Length)} is not valid");

private static readonly Func<string, string> CanNotStartsWithCharA =
    name => $"{name} can not start with char 'A'";
```

Default factories for exceptions:
- ArgumentException
- ArgumentNullException
- ArgumentOutOfRangeException
- ValidationException

Default validators:
- IsNull()
- IsEmpty()

Default message templates:
- _$"{name} can not be null"_
- _$"{name} can not be empty"_

## Extend

To use any other exception there is an IExceptionFactory interface:

```c#
using ThrowIf;
using static ThrowIf.MessageTemplates;

Throw<CustomExceptionFactory>
    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: CanNotBeNull)
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: CanNotBeNull)
    .If(condition: text.Length < 10, message: $"{nameof(text.Length)} is not valid");

public sealed class CustomExceptionFactory : IExceptionFactory
{
    public Exception CreateInstance(string message) => new CustomException(message);
}
```

To reduce the amount of code there is an IConditionGroup<in T> interface:

```c#
using ThrowIf;
using ThrowIf.Exceptions;
using static ThrowIf.MessageTemplates;

Throw<ArgumentExceptionFactory>
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: CanNotBeNull)
    .If(conditionGroup: new TextValidator(), value: text);

public sealed class TextValidator : IConditionGroup<string>
{
    public void Verify(in ThrowContext context, string text)
    {
        context
            .If(text.Length < 100, $"{nameof(text.Length)} can not be less than 100")
            .If(text.StartsWith("A"), $"{nameof(text)} can not start with char 'A'")
            .If(text.EndsWith("B"), $"{nameof(text)} can not end with char 'B'");
    }
}
```

