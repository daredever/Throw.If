# Throw.If

A high-performance validation library with support of C# 8.0 [nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references).

## Use

```c#
using ThrowIf;

Throw.ArgumentNullException()
    .If(guid.IsNull(), nameof(guid))
    .If(text.IsNull(), nameof(text));

Throw.ArgumentException(name => $"Invalid argument '{name}'")
    .If(text.IsEmpty(), nameof(text))
    .If(text.Length > 1, nameof(text.Length))
    .If(guid.IsEmpty(), nameof(guid));
```

Default exceptions:
- ArgumentNullException
- ArgumentException
- ValidationException
- InvalidOperationException

Default validators:
- IsNull()
- IsEmpty()

Default message templates:
- _$"{name} can not be null"_
- _$"{name} can not be empty"_
- _$"{name} is not valid"_

## Extend

To use any other exception define factory:

```c#
using ThrowIf;

Throw.Exception((name, message) => new CustomException(message), name => $"Wrong parameter '{name}'")
    .If(text.IsNull() || text.StartsWith('A'), nameof(text))
    .If(text.Length < 100, nameof(text.Length), name => $"{name} is too small");
```

To reduce the amount of code implement an IConditionGroup interface:

```c#
using ThrowIf;
using static ThrowIf.MessageTemplates;

Throw.ArgumentException()
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: CanNotBeNull)
    .If(conditionGroup: new TextValidator(), value: text);

public sealed class TextValidator : IConditionGroup<string>
{
    public void Verify(in ThrowContext context, string text)
    {
        context
            .If(text.Length < 100, nameof(text.Length), name => $"{name} can not be less than 100")
            .If(text.StartsWith('A'), nameof(text), name => $"{name} can not start with char 'A'")
            .If(text.EndsWith('B'), nameof(text), name => $"{name} can not end with char 'B'");
    }
}
```

To add new checks extend ThrowContext with extension (impossible to use nullable reference types attributes in some cases):

```c#
using ThrowIf;

Throw.Exception<ArgumentExceptionFactory>()
    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull)
    .IfEmpty(value: text, name: nameof(text));

public static class ThrowExtensions
{
    public static ref readonly ThrowContext IfEmpty(this in ThrowContext context,
        string value, string name)
    {
        return ref context.If(value.IsEmpty(), name, MessageTemplates.CanNotBeEmpty);
    }
}
```

