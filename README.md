# Throw.If
Argument validation library.

```c#
Throw<ArgumentNullExceptionFactory>
    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: CanNotBeNull)
    .If(condition: message.IsNull(), name: nameof(message), messageTemplate: CanNotBeNull);

Throw<ValidationExceptionFactory>
    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: CanNotBeEmpty)
    .If(condition: message.IsEmpty(), name: nameof(message), messageTemplate: CanNotBeEmpty)
    .If(message.Length > 10, $"{nameof(message.Length)} is not valid");

Throw<CustomException>
    .If(conditionGroup: MessageValidator.Instance, value: message);
```
