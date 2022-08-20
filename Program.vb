Module Module1
    Sub Main(args As String())
        Dim planets(9) As Planet
        Dim p1 As Planet ' A variable that is required to use the function CreatePlanet

        ' Initialising the array
        For count = 0 To 9
            planets(count) = CreatePlanet(p1, "None", "None", "None", "None", "None")
        Next

        ' Dummy Planets just to testing purposes
        planets(0) = CreatePlanet(p1, "DummyPlanet1", "20,000", "57,600", "1200", "365")
        planets(1) = CreatePlanet(p1, "DummyPlanet2", "13,000", "49,000", "470", "1842")
        planets(2) = CreatePlanet(p1, "DummyPlanet3", "9,000", "17,405", "42,700", "782")

        Dim welcome_message As String = ("
List of commands: 
----------------------------------------------------------------------------------------------
        0. To display this message

        1. Display all the planets.
        2. Search details about a specific planet.

        3. Display all the planets as in the order of the biggest in size.
        4. Display all the planets as in the order of the smallest in size.

        5. Display all the planets as in the order of the furthest to the Sun.
        6. Display all the planets as in the order of the closest to the Sun.


        7. Display all the planets as in the order of the highest revolution around the sun
        8. Display all the planets as in the order of the smallest revolution around the sun
    
        9. Display all the planets in alphabetical order

        10. Add a planet (max: 10)
        11. Remove a planet from the list.

        12. Clear window
----------------------------------------------------------------------------------------------
")
        Console.WriteLine(welcome_message)

        Dim command As String ' String so as of a command like 'a' is inserted, the program will not crash

        While True

            Console.WriteLine()
            Console.Write("Enter the command index: ")
            command = Console.ReadLine()

            Dim compact_order() As Planet = CompactOrder(planets)

            Select Case command
                Case 0 ' Display welcome message
                    Console.WriteLine(welcome_message)

                Case 1 ' Display all the planets in the list 
                    If Not isEmpty(planets) Then

                        For planet = 0 To compact_order.Length() - 1
                            EasyDisplay(planets(planet))
                        Next

                    End If

                Case 2 ' Search for a planet in the list
                    Console.Write("Enter the name you want to search: ")
                    Dim search As String
                    search = Console.ReadLine

                    Dim found As Boolean = False
                    Dim count As Integer = 0
                    While True
                        If planets(count).name = search Then
                            EasyDisplay(planets(count))
                            found = True
                        End If

                        If found Or count = planets.Length() - 1 Then Exit While
                        count += 1
                    End While

                    If Not found Then
                        Console.WriteLine()
                        Console.WriteLine("[!] Sorry there is no such planet in the list")
                    End If

                Case 3 ' Sort by biggest to smallest
                    Dim temp As Planet
                    If Not isEmpty(planets) Then

                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If CDbl(compact_order(j).mass) < CDbl(compact_order(j + 1).mass) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next


                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next

                    End If


                Case 4 ' Sort by smakest to highest

                    Dim temp As Planet
                    If Not isEmpty(planets) Then
                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If CDbl(compact_order(j).mass) > CDbl(compact_order(j + 1).mass) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next

                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next
                    End If

                Case 5 ' Sort by furthest to closest
                    Dim temp As Planet

                    If Not isEmpty(planets) Then
                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If CDbl(compact_order(j).distance) < CDbl(compact_order(j + 1).distance) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next


                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next
                    End If

                Case 6 ' Sort by closest to furthest

                    Dim temp As Planet

                    If Not isEmpty(planets) Then
                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If CDbl(compact_order(j).distance) > CDbl(compact_order(j + 1).distance) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next


                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next
                    End If

                Case 7 ' Sort by highest revolution to smallest
                    Dim temp As Planet

                    If Not isEmpty(planets) Then
                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If CDbl(compact_order(j).revolution) < CDbl(compact_order(j + 1).revolution) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next

                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next
                    End If

                Case 8 ' Sort by smallest revolution to highest

                    Dim temp As Planet

                    If Not isEmpty(planets) Then
                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If CDbl(compact_order(j).revolution) > CDbl(compact_order(j + 1).revolution) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next


                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next
                    End If

                Case 9 ' Sort by closest to furthest

                    Dim temp As Planet

                    If Not isEmpty(planets) Then
                        For i = 0 To compact_order.Length() - 2
                            For j = 0 To compact_order.Length() - 2
                                If (compact_order(j).name) > (compact_order(j + 1).name) Then
                                    temp = compact_order(j)
                                    compact_order(j) = compact_order(j + 1)
                                    compact_order(j + 1) = temp
                                End If
                            Next
                        Next


                        For i = 0 To compact_order.Length() - 1
                            EasyDisplay(compact_order(i))
                        Next

                    End If

                Case 10 ' Add item to the list
                    If compact_order.Length() = planets.Length() Then
                        Console.WriteLine()
                        Console.WriteLine("[!] Sorry but the list is full!")
                        Console.WriteLine()
                    Else
                        Dim len As Integer = compact_order.Length()
                        While True
                            Dim add_order() As Planet = CompactOrder(planets)
                            Console.Write("Enter the name of the new planet: ")
                            Dim NName As String = Console.ReadLine
                            For i = 0 To compact_order.Length() - 1 ' Checks if planet already exists
                                If compact_order(i).name = NName Then
                                    Console.WriteLine("[!] The list already contains a planet under that name.")
                                    Exit While
                                End If
                            Next
                            Console.Write("Enter the diameter of the new planet: ")
                            Dim NDiameter As String = Console.ReadLine
                            Console.Write("Enter the mass of the new planet: ")
                            Dim NMass As String = Console.ReadLine
                            Console.Write("Enter the distance of the new planet: ")
                            Dim NDistance As String = Console.ReadLine
                            Console.Write("Enter the revolution of the new planet: ")
                            Dim NRevolution As String = Console.ReadLine

                            Dim place_found As Boolean = False
                            Dim pos As Integer = -1

                            While Not place_found
                                pos += 1
                                If planets(pos).name = "None" Then
                                    planets(pos) = CreatePlanet(p1, NName, NDiameter, NMass, NDistance, NRevolution) ' NName -> New name ...
                                    place_found = True
                                    Console.WriteLine()
                                    Console.WriteLine("Planet " & planets(pos).name & " has been successfully created")
                                End If

                                If pos = planets.Length() - 1 Then
                                    Exit While
                                End If

                            End While

                            If pos = planets.Length() - 1 Then
                                Console.WriteLine()
                                Console.Write("[!] The list is now full")
                                Console.ReadLine()
                                Exit While
                            End If

                            Console.WriteLine()
                            Console.WriteLine("Do you want to add another planet to the list?")
                            Console.Write("If you don't wish to type 'no' or 'end' otherwise type 'yes': ")

                            Dim choice As String = Console.ReadLine()
                            If choice = "no" Or choice = "end" Then
                                Exit While

                            ElseIf choice = "yes" Then

                                Console.WriteLine()
                                Console.WriteLine("Ok! Another one")
                                Console.WriteLine()
                            Else
                                Console.WriteLine()
                                Console.WriteLine("[!] Invalid command.")
                                Exit While

                            End If

                        End While
                    End If

                Case 11 ' Remove item from the list
                    If compact_order.Length() = 0 Then
                        Console.WriteLine()
                        Console.WriteLine("The list is currently full")
                        Console.WriteLine()
                    Else
                        Console.Write("Enter the name of the planet you want to remove: ")
                        Dim search As String = Console.ReadLine

                        Dim found As Boolean = False

                        For i = 0 To compact_order.Length() - 1
                            If planets(i).name = search Then
                                found = True
                                planets = RemoveByShifting(planets, search)
                                Console.WriteLine()
                                Console.WriteLine("Removing Planet " & search & " was successfull")
                                Exit For

                            End If
                        Next

                        If Not found Then
                            Console.WriteLine("[!] Planet " & search & " is not in the list!")
                        End If

                    End If

                Case 12 ' Clear Console
                    Console.Clear()
                    Console.WriteLine(welcome_message)

                Case -1 ' Quit the program
                    Console.WriteLine()
                    Console.WriteLine("[*] Thank you!")
                    Exit While

                Case Else ' If any other commands in input
                    Console.WriteLine()
                    Console.WriteLine("[!] Invalid Command")

            End Select
        End While


        Console.ReadKey()
    End Sub

    ' It removes an item from the list and that data that were after that item will be shifted up to the from 
    ' To illustrate: 
    ' if p3 had to be removed from the list [p1, p2, p3, p4, p5]
    ' Instead of it resulting in [p1, p2, None, p4, p5]
    ' It will be [p1, p2, p4, p5, None]
    ' So that it can work for CompactOrder function because as soon as it detects a None value it returns the previous data as a list
    Function RemoveByShifting(list() As Planet, search As String) As Planet()
        Dim pos As Integer

        For i = 0 To list.Length() - 1
            If list(i).name = search Then
                pos = i
            End If
        Next

        Dim dummy_planet As Planet
        list(pos) = CreatePlanet(dummy_planet, "None", "None", "None", "None", "None")

        Dim count As Integer = pos
        Dim temp As Planet

        If pos <> list.Length() - 1 Then
            While pos <> list.Length() - 1
                If list(pos + 1).name <> "None" Then

                    temp = list(pos)
                    list(pos) = list(pos + 1)
                    list(pos + 1) = temp

                    If pos = list.Length() - 1 Then
                        Exit While
                    End If

                End If
                pos += 1
            End While
        End If

        Return list
    End Function

    ' Compact order is a way to compress the planets array so that it can return an array without any "None" values
    ' It is easier for searching and also display
    Function CompactOrder(list() As Planet) As Planet()
        Dim count As Integer
        ' Calculate how many elements there is the planets array that is not NONE
        For i = 0 To list.Length() - 1
            If list(i).name <> "None" Then
                count += 1
            End If
        Next

        Dim compact_order(count - 1) As Planet
        For i = 0 To count - 1
            compact_order(i) = list(i)
        Next

        Return compact_order

    End Function

    ' Checks if the list is empty
    Function isEmpty(list() As Planet) As Boolean
        If list(0).name = "None" Then
            Console.WriteLine()
            Console.WriteLine("[!] The list of planets is currently empty.")
            Console.WriteLine()
            Return True

        Else
            Return False
        End If

    End Function


    Structure Planet
        Dim name As String
        Dim diameter As String
        Dim mass As String
        Dim distance As String ' Distance from the Sun 
        Dim revolution As String ' The amount of time it takes to rotate around the Sun  ( In days )
    End Structure

    Function CreatePlanet(ByRef planet As Planet, ByVal new_name As String, ByVal new_diameter As String, ByVal new_mass As String, ByVal new_distance As String, ByVal new_revolution As String) As Planet
        planet.name = new_name
        planet.diameter = new_diameter
        planet.mass = new_mass
        planet.distance = new_distance
        planet.revolution = new_revolution

        Return planet
    End Function

    ' Easier and better way to display the information about the planets
    Sub EasyDisplay(ByVal planet As Planet)
        Console.WriteLine("
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Planet's name: " & planet.name & "
        Planet's diameter: " & planet.diameter & " km
        Planet's mass: " & planet.mass & " million kg
        Planet's distance from the Sun: " & planet.distance & " million km
        planet's number of days for 1 complete revolution around the Sun: " & planet.revolution & " days
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
            )
        Console.WriteLine() ' Empty line for better visual
    End Sub


End Module