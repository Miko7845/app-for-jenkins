using OpenDialogWindowHandler;

namespace LibraryUserinterface.Utilities
{
    public static class DialogWindowHandler
    {
        static HandleOpenDialog s_window = new HandleOpenDialog();
        public static void UplaodFile(string path, string name) => s_window.fileOpenDialog(path, name);
    }
}
