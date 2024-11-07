# winformZoomOut Application

## English Version

### Description
The `winformZoomOut` application is a Windows Forms project demonstrating how to minimize an application window to the system tray and display a notification icon. This allows users to hide the main application window while keeping the program running in the background, offering a user-friendly way to manage system resources and notifications.

### Features
- Minimize the main window to the system tray.
- Display a balloon tip notification when minimized.
- Restore the application window by clicking the system tray icon or using the context menu.
- Includes a "Restore" option in the context menu for user convenience.
- Properly disposes of the `NotifyIcon` to prevent resource leaks.

### Code Overview
1. **Initialization**: `NotifyIcon` is initialized when the application is minimized for the first time. It includes setting the icon and balloon tip text.
2. **Event Handlers**:
   - `ZoomOut_Click`: Calls the `Zoom()` method to minimize the window.
   - `MyNotifyIcon_Click` and `NotifyIconMenuItem1_Click`: Restores the window when the system tray icon or context menu item is clicked.
3. **Error Handling**: The code handles `FileNotFoundException` to notify the user if the icon file is missing.
4. **Form Closing**: Ensures `NotifyIcon` is properly disposed when the application closes to avoid memory leaks.

### Usage
1. Run the application.
2. Click the "Zoom Out" button to minimize the window to the system tray.
3. Hover over the tray icon to see the balloon tip.
4. Click the tray icon or choose "Restore" from the context menu to reopen the window.
5. Closing the application ensures proper disposal of the `NotifyIcon`.

### Code Snippet
```csharp
private void Zoom()
{
    if (notifyIcon == null)
    {
        notifyIcon = new NotifyIcon();
    }
    notifyIcon.BalloonTipText = "Hover text for the tray icon";
    notifyIcon.Text = "Title when minimized";
    try
    {
        notifyIcon.Icon = new Icon("nhi_logo.ico");
    }
    catch (FileNotFoundException)
    {
        MessageBox.Show("Icon file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    notifyIcon.Visible = true;
    ShowInTaskbar = false;
    Hide();
    notifyIcon.ShowBalloonTip(1000, "Program still Running", "Your program now listening......", ToolTipIcon.Info);
}
```

# winformZoomOut 應用程式

## 描述
`winformZoomOut` 是一個 Windows Forms 專案，演示了如何將應用程式視窗縮小至系統托盤並顯示通知圖示。此功能允許使用者在隱藏主視窗的同時保持程式在背景中運行，提供了友善的用戶體驗以更好地管理系統資源和通知。

## 功能
- 將主視窗縮小至系統托盤。
- 在縮小時顯示氣球提示通知。
- 點擊系統托盤圖示或使用上下文選單恢復應用程式視窗。
- 上下文選單中包含「復原」選項，增強用戶交互性。
- 正確釋放 `NotifyIcon` 資源以防止資源洩漏。

## 程式碼概述
1. **初始化**：`NotifyIcon` 在應用程式第一次縮小時初始化，並設置圖示和氣球提示文字。
2. **事件處理**：
   - `ZoomOut_Click`：調用 `Zoom()` 方法縮小視窗。
   - `MyNotifyIcon_Click` 和 `NotifyIconMenuItem1_Click`：當點擊系統托盤圖示或上下文選單項時恢復視窗。
3. **錯誤處理**：代碼處理 `FileNotFoundException`，當圖示文件遺失時通知用戶。
4. **視窗關閉**：確保應用程式關閉時正確釋放 `NotifyIcon` 以避免記憶體洩漏。

## 使用方法
1. 執行應用程式。
2. 點擊「縮小」按鈕將視窗縮小至系統托盤。
3. 將滑鼠移至托盤圖示上可看到氣球提示。
4. 點擊托盤圖示或從上下文選單中選擇「復原」以重新打開視窗。
5. 關閉應用程式以確保 `NotifyIcon` 被正確釋放。

## 程式碼片段
```csharp
private void Zoom()
{
    if (notifyIcon == null)
    {
        notifyIcon = new NotifyIcon();
    }
    notifyIcon.BalloonTipText = "滑鼠移動到Icon上要顯示的文字";
    notifyIcon.Text = "縮小視窗的標題";
    try
    {
        notifyIcon.Icon = new Icon("nhi_logo.ico");
    }
    catch (FileNotFoundException)
    {
        MessageBox.Show("Icon file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    notifyIcon.Visible = true;
    ShowInTaskbar = false;
    Hide();
    notifyIcon.ShowBalloonTip(1000, "Program still Running", "Your program now listening......", ToolTipIcon.Info);
}

