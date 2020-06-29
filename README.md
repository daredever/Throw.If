# Throw.If

A high-performance validation library with support of C# 8.0 [nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references).

## Use

```c#
using ThrowIf;

Throw.Exception<ArgumentNullExceptionFactory>()
    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeNull)
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull);

Throw.Exception<ArgumentExceptionFactory>()
    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeEmpty)
    .If(condition: guid.Value.ToString().StartsWith("A"), name: nameof(guid), messageTemplate: CanNotStartsWithCharA);

Throw.Exception(new ValidationExceptionFactory())
    .If(condition: text.IsEmpty(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeEmpty)
    .If(condition: text.Length > 10, message: $"{nameof(text.Length)} is not valid")
    .If(condition: text.Length < 100, messageTemplate: () => $"{nameof(text.Length)} is not valid");
              
Throw.Exception(message => new ArgumentException(message))
    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeEmpty);

private static readonly Func<string, string> CanNotStartsWithCharA =
    name => $"{name} can not start with char 'A'";
```

Default factories for exceptions:
- ArgumentException
- ArgumentNullException
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

Throw.Exception<CustomExceptionFactory>()
    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: CanNotBeNull)
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: CanNotBeNull);

Throw.Exception(message => new CustomException(message))
    .If(condition: text.Length < 10, message: $"{nameof(text.Length)} is not valid");

public sealed class CustomExceptionFactory : IExceptionFactory
{
    public Exception CreateInstance(string message) => new CustomException(message);
}
```

To reduce the amount of code there is an IConditionGroup interface:

```c#
using ThrowIf;
using static ThrowIf.MessageTemplates;

Throw.Exception<ArgumentExceptionFactory>()
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

To add new checks write new extensions (impossible to use nullable reference types attributes):

```c#
using ThrowIf;

Throw.Exception<ArgumentExceptionFactory>()
    .IfNull(value: text, name: nameof(text))
    .IfEmpty(value: text, name: nameof(text));

public static class ThrowExtensions
{
    public static ref readonly ThrowContext IfNull<T>(this in ThrowContext context,
        T? value, string name) where T : class
    {
        return ref context.If(value.IsNull(), name, MessageTemplates.CanNotBeNull);
    }

    public static ref readonly ThrowContext IfEmpty(this in ThrowContext context,
        string value, string name)
    {
        return ref context.If(value.IsEmpty(), name, MessageTemplates.CanNotBeEmpty);
    }
}
```

