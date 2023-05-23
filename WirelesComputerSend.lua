term.clear ()
term.setCursorPos(1,1)

local modem = peripheral.find("modem")

modem.open(69)
while true do

    input = read()
    
    modem.transmit(69,69,read)
    print("Sent!")
   
end
