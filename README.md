# wf-how-to-customize-appearance-of-sfbutton

This sample demonstrates how to customize the appearance of the Syncfusion WinForms `SfButton` control by rendering it with rounded edges. The sample places an `SfButton` on a Windows Form and customizes its visual states by setting different border, background, and foreground colors for normal, hover, focused, pressed, and disabled states.

To achieve the rounded appearance, the sample handles the button’s `Paint` event and draws a custom rounded rectangle path by using `GraphicsPath`. The button region is updated with this rounded shape, and the border color is selected dynamically based on the current interaction state.

The sample also handles `MouseDown`, `MouseUp`, `MouseHover`, and `MouseLeave` events to track interaction states and refresh the control. This approach is useful when you want an `SfButton` with a rounded style while still using the built-in appearance customization options provided by Syncfusion WinForms controls in different button states.
