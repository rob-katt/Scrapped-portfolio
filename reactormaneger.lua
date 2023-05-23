term.clear ()
term.setCursorPos(1,1)
graystatus = 0
whitestatus = 0

--[[
some docementation on how to set it up in minecraft.
black is if the fustion lasers is charged
gray to turn fire the fusion lasers
cyan is if the fusion reactor is on
--]]

while true do
    
    -- outputs both to gray and white redstone bundle
    redstone.setBundledOutput("top",graystatus + whitestatus)

    input = read()
    if input == "commands" then
    print("stats - shows the reactors statistics in text")
    print("fitoggle - toggles the fission reactor")
    print("fuignite - starts the fussion reactor")
    end
   
    if input == "stats" then
        if whitestatus = 0 then
            print ("fision reactor is on")
        end
        -- checks if there is a signal comming from a redstone bundle
        if colors.test(topinput, colors.cyan) then
            print ("fusion reactor is on")
        end
    end

    if input == "fitoggle" then 
    
        if colors.test(topinput, colors.white)then
            print("turning off")
        whitestatus = 0
        else whitestatus = 1
        end
            

            
    end
    
    topinput = rs.getBundledInput("top")

    if input == "fuignite" and colors.test(topinput, colors.black) and not colors.test(topinput, colors.cyan) then
    print("bam")
    graystatus = 2^7
    turnoflaser = true
    
    end
    if input == "fuignite" and not colors.test(topinput, colors.black) then
        print("!not charged!")
        
    end
    if input == "fuignite" and colors.test(topinput, colors.cyan) then
        print("!already on!")
        
    end 
        
        


    if  turnoflaser then 
        redstone.setBundledOutput("top",graystatus)
        os.sleep(1)
        graystatus = 0
        
    end
end
