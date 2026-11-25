// Native <dialog> helpers for Lightbox.razor.
export function init(dialog, dotnet) {
  const onClick = (e) => { if (e.target === dialog) dialog.close(); }; // backdrop click closes
  const onClose = () => dotnet.invokeMethodAsync("OnDialogClosed");
  dialog.addEventListener("click", onClick);
  dialog.addEventListener("close", onClose);
  return {
    dispose() {
      dialog.removeEventListener("click", onClick);
      dialog.removeEventListener("close", onClose);
    }
  };
}

export function open(dialog) {
  if (typeof dialog.showModal === "function" && !dialog.open) dialog.showModal();
}

export function close(dialog) {
  if (dialog.open) dialog.close();
}
