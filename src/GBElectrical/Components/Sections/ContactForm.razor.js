// Posts the enquiry to Web3Forms from the browser. Resolves true only when Web3Forms reports success.
export async function send(payload) {
  try {
    const res = await fetch("https://api.web3forms.com/submit", {
      method: "POST",
      headers: { "Accept": "application/json", "Content-Type": "application/json" },
      body: JSON.stringify(payload)
    });
    const data = await res.json();
    return res.ok && !!data.success;
  } catch {
    return false;
  }
}

// Blazor marks invalid inputs with the "invalid" class; focus the first one.
export function focusFirstInvalid(formId) {
  const el = document.getElementById(formId)?.querySelector(".invalid");
  if (el) el.focus();
}
