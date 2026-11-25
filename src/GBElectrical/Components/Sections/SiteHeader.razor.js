// Mobile menu helpers for SiteHeader.razor (matches js/main.js in the static build).
// - Escape anywhere closes the open menu.
// - Clicking a menu link closes the menu *synchronously*, before the browser scrolls to the anchor.
//   Waiting for the server round-trip would scroll with the menu still open and overshoot the section.
export function init(menu, toggle, dotnet) {
  const onKey = (e) => { if (e.key === "Escape") dotnet.invokeMethodAsync("OnEscape"); };
  const onClick = (e) => {
    if (!e.target.closest("a") || !menu.classList.contains("is-open")) return;
    menu.classList.remove("is-open");
    toggle.setAttribute("aria-expanded", "false");
    toggle.setAttribute("aria-label", "Open menu");
    dotnet.invokeMethodAsync("OnLinkClicked");
  };
  document.addEventListener("keydown", onKey);
  menu.addEventListener("click", onClick);
  return {
    dispose() {
      document.removeEventListener("keydown", onKey);
      menu.removeEventListener("click", onClick);
    }
  };
}
