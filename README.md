# Type Discrimantor is lost when serializing using TranslateResultToActionResult

### Reproduction steps:
1. Run the project
2. Open [swagger](http://localhost:5162/swagger/index.html)
3. Call the /api/Foo/normal endpoint
4. Observe: the result contains the type discriminator "$type": "Foo",
5. Call the /api/Foo/result endpoint
6. Observe: the type discriminator is missing

### Expected behavior:
Returning a Result\<T\> should have the same serialization behavior as returning T when using TranslateResultToActionResult.