# Task 4 quick note for agent

Source: `Task_4.pdf`

## UI pages required
- Login page for non-authenticated users.
- Registration page with immediate account creation and async email confirmation notice.
- User management page with one shared toolbar above the table.
- Blocked/deleted redirect scenario back to login.

## Table and toolbar constraints
- Columns: selection checkbox, name, e-mail, last login/activity, status.
- Leftmost header cell must contain only select-all checkbox.
- Sorting required (example: last login descending).
- Multi-select via checkboxes only (including select all).
- No per-row action buttons.
- Toolbar always visible with actions: Block, Unblock, Delete, Delete unverified.

## Back-end constraints to implement later
- DB must include a unique index for e-mail (storage-level uniqueness guarantee).
- Before every request except login/register, check that user exists and is not blocked.
- Blocked users cannot login.
- Deleted users are physically deleted and can re-register later.
