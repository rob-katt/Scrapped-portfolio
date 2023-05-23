term.clear ()
term.setCursorPos(1,1)

-- uses CC:Tweaked's api to find the "modem" which is like a radio in this game
local modem = peripheral.find("modem")

-- opens the radio channel 69 so it can listen to whats being sent there
modem.open(69)
while true do

    input = read()
    
    -- transmits a message at channel 69 and waits for a response on the same channel
    modem.transmit(69,69,read)
    print("Sent!")
   
end
