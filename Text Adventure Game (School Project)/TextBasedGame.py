#Name:Alexander Sufran

def main_menu():
    # Print instructions and intro
    print("Cyberspace Adventure Game")
    print("Collect the 6 Control Chips for your Buster Gauntlet to save Queen Autumn, or be corrupted by the virus that plagues her programming.")
    print("Move commands: go South, go North, go East, go West")
    print("Add to Inventory: get 'item name'")


def move_between_rooms(current_room, move, rooms):
    # move to corresponding room
    current_room = rooms[current_room][move]
    return current_room


def get_item(current_room, move, rooms, inventory):
    # add item to inventory and remove it from the room
    inventory.append(rooms[current_room]['item'])
    del rooms[current_room]['item']


def main():
    # dictionary of connecting rooms with items
    rooms = {
        'Cyberspace Entrance': {'South': 'Main Server', 'East': 'Ethernet Port'},
        'Ethernet Port': {'West': 'Cyberspace Entrance', 'item': 'Firewall'},
        'Main Server': {'West': 'Cloud', 'North': 'Cyberspace Entrance', 'South': 'Glitch Dungeon', 'East': 'Data Processing Center', 'item': 'Reboot'},
        'Cloud': {'East': 'Main Server', 'item': 'Code Debugger'},
        'Glitch Dungeon': {'East': 'Web Browser', 'North': 'Main Server', 'item': 'Anti-Virus'},
        'Web Browser': {'West': 'Glitch Dungeon', 'item': 'Trojan Horse'},
        'Data Processing Center': {'West': 'Main Server', 'North': 'Queen Autumns Lair', 'item': 'Virus Scan'},
        'Queen Autumns Lair': ''
    }
    s = ' '
    # list for storing player inventory
    inventory = []
    # starting room
    current_room = "Cyberspace Entrance"
    # show the player the main menu
    main_menu()

    while True:
        # when player encounters the 'villain'
        if current_room == 'Queen Autumns Lair':
            # Good Ending
            if len(inventory) == 6:
                print('You have successfully debugged and wiped the virus from Queen Autumns Programming!')
                print('Thank you for playing!')
                break
            # Bad Ending
            else:
                print('\nOh no! You did not collect all of your control chips for your Buster Gauntlet!')
                print('Queen Autumn has taken over your programming and you now serve as her slave in her new cyberspace domain dubbed The Realm of the Glitch Queen!')
                print('Thank you for playing!')
                break
        # state to the player their current room, inventory and prompt for a move
        print('You are in the ' + current_room)
        print(inventory)
        # tell the user if there is an item in the room
        if current_room != 'Queen Autumns Lair' and 'item' in rooms[current_room].keys():
            print('You see the {}'.format(rooms[current_room]['item']))
        print('------------------------------')
        move = input('Enter your move: ').title().split()

        # handle if the players enters a command to move to a new room
        if len(move) >= 2 and move[1] in rooms[current_room].keys():
            current_room = move_between_rooms(current_room, move[1], rooms)
            continue
        # handle if the player enters a command to get an item
        elif len(move[0]) == 3 and move[0] == 'Get' and ' '.join(move[1:]) in rooms[current_room]['item']:
            print('You pick up the {}'.format(rooms[current_room]['item']))
            print('------------------------------')
            get_item(current_room, move, rooms, inventory)
            continue
        # handle if the player enters an invalid command
        else:
            print('Invalid move, please try again')
            continue


main()