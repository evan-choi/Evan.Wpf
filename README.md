# WPF Extension
WPF Extension

A library help to WPF Programming

# Basic usage

**Using namespace**
```cs
using WPFExtension;
```
<br />
## DependencyHelper
**Basic Register**
```cs
// Basic Register Dependency Property
public static DependencyProperty TextProperty =
        DependencyHelper.Register();
        
public string Text
{
    get { return (string)GetValue(TextProperty); }
    set { SetValue(TextProperty, value); }
}
```
<br />
**Basic Register - Exception Sample**
```cs
// Throw DependencyHelperException
public static DependencyProperty TextProperty =
        DependencyHelper.Register();
        
public string Title
{
    get { return (string)GetValue(TextProperty); }
    set { SetValue(TextProperty, value); }
}
```
<br />
**Register only**
```cs
// Register Only Dependency Property
public static DependencyProperty TextProperty =
        DependencyHelper.Register<string>();
        
// It is not necessary string property.
```
<br />
**Add Value Changed from DependencyPropertyDescriptor**
```cs
// Add Event
<DependencyProperty>.AddValueChanged(<Parent(DependencyObject)>, <EventHandler>);

// Remove Event
<DependencyProperty>.RemoveValueChanged(<Parent(DependencyObject)>, <EventHandler>);
```
