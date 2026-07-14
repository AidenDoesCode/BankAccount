# Bank Account Manager

A menu-driven console app for managing multiple bank accounts — create accounts, deposit, withdraw, and check balances.

## What it does

1. Displays a menu with options to:
   1. Create a new account
   2. Deposit money into an account
   3. Withdraw money from an account
   4. Check accounts (list all accounts and balances)
   5. Quit the program
2. Supports multiple accounts at once, stored in a list
3. Validates all user input — rejects non-numeric menu choices, invalid amounts, and account names containing numbers or special characters

## Concepts practiced

- Classes, constructors (including overloads), and properties
- **Encapsulation:** `Balance` has a public getter but a `private` setter, so the balance can only be changed through the `Deposit`/`Withdraw` methods — external code can read it but can't bypass validation to set it directly
- `List<Bank>` for managing multiple account objects
- `int.TryParse` for safely validating numeric input without crashing on bad input
- Regex for validating account names (`^[a-zA-Z]+$` — letters only)
- Menu-driven program flow with nested input-validation loops

## Project structure

- `Bank.cs` — the `Bank` class: fields, constructors, `Balance`/`Name` properties, `Deposit`/`Withdraw` methods
- `Main.cs` — the console menu, input handling, and program loop

## Bugs hit and fixed along the way

- **Method name/signature mismatch:** case 4 originally called `printAccounts()` (wrong casing, missing argument) instead of the actual method `PrintAccounts(accounts)` — caused a compile error
- **Public setter undermined validation:** `Balance` originally had a public setter, meaning external code could set an account's balance directly (even negative), completely bypassing the checks inside `Deposit`/`Withdraw`. Fixed by making the setter `private`, so balance changes are only possible through the validated methods

## Possible future improvements

- Add an `else` branch to the withdraw option for when no accounts exist yet (currently only the deposit option handles this case)
- Support multi-word account names (current regex rejects spaces)
- Add account lookup by name instead of only by list position
