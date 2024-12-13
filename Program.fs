open System

module DictionaryApp =

    // Define the type of dictionary
    type Dictionary = Map<string, string>

    // Add a new word to the dictionary
    let addWord (word: string) (definition: string) (dict: Dictionary) =
        if dict.ContainsKey(word.ToLower()) then
            printfn "The word '%s' already exists. Use updateWord to change the definition." word
            dict
        else
            dict.Add(word.ToLower(), definition)

    // Update the definition of an existing word
    let updateWord (word: string) (newDefinition: string) (dict: Dictionary) =
        if dict.ContainsKey(word.ToLower()) then
            dict.Add(word.ToLower(), newDefinition)
        else
            printfn "The word '%s' does not exist. Use addWord to add it first." word
            dict

    // Delete a word from the dictionary
    let deleteWord (word: string) (dict: Dictionary) =
        if dict.ContainsKey(word.ToLower()) then
            dict.Remove(word.ToLower())
        else
            printfn "The word '%s' was not found in the dictionary." word
            dict

    // Example usage
    [<EntryPoint>]
    let main argv =
        // Create an empty dictionary
        let mutable dictionary: Dictionary = Map.empty

        // Add words
        dictionary <- addWord "Computer" "A programmable electronic device" dictionary
        dictionary <- addWord "Algorithm" "A step-by-step procedure for calculations" dictionary

        // Update a word
        dictionary <- updateWord "Computer" "An electronic device that processes data" dictionary

        // Delete a word
        dictionary <- deleteWord "Algorithm" dictionary

        // Display the current dictionary
        printfn "Current Dictionary: %A" dictionary

        0 // Exit code
