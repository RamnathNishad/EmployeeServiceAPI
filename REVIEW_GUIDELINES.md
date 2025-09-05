2. Employee null value validation must be done before using it.
   - **Rationale:** Validating that the employee object is not null before accessing its properties or methods prevents runtime errors and ensures application stability.
   - **Implementation Requirements:** Always check if the employee object is not null (and not undefined) before using it. Use explicit null checks such as `if (employee != null)` or `if (employee !== null && employee !== undefined)`. Avoid relying solely on truthy/falsy checks for objects.
   - **Example:**
     ```typescript
     // Correct null check
     if (employee != null) {
         console.log(employee.name);
     }
     // Incorrect: may throw error if employee is null
     console.log(employee.name);
     ```
