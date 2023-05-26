from os import listdir, mkdir
from os.path import isfile, join, splitext, isdir

#################################################################################################
#                                                                                               #
# Bootstrap Icon extractor                                                                      #
#                                                                                               #
# Created by: Guillermo Espert Carrasquer, 2023                                                 #
# License: MIT                                                                                  #
#                                                                                               #
#################################################################################################
#                                                                                               #
# Description:                                                                                  #
# --------------------------------------------------------------------------------------------- #
# The aim of this script is to help extracting and generating the code needed                   #
# to create an enum defining all available icons, and generate                                  #
# the helper class containing the SVG markup for each icon defined in the enum.                 #
#                                                                                               #
# This script will be helpfull when the update of the C# would be needed to                     #
# add the new icons added to the Bootstrap Icon collection, whitout the need to write           #
# new constants by hand.                                                                        #
#                                                                                               #
# Use:                                                                                          #
# --------------------------------------------------------------------------------------------- #
# Download from the Bootstrap website the zip file containing all icon SVG files and extract    #
# it into your local disk.                                                                      #
#                                                                                               #
# You must provide below the path to the Bootstrap Icons folder containing all SVG files        #
# you want to extract and an output directory path to place the C# generated files.             #
#                                                                                               #
#################################################################################################

# Set the path to the icon SVG files
pathToSvgFiles = ""

# Set the path for the output C# files
outputDirectoryPath = ""

# Set BootstrapIcons current version
bsiVersion = ""

# Extract all SVG file names and generates an enum containing all file names. #####################################

foundFiles = [f for f in listdir(pathToSvgFiles) if isfile(join(pathToSvgFiles, f))]
enumConstants = []

for f in foundFiles:
    fileInfo = splitext(f)

    if fileInfo[1] == '.svg':

        tokens = fileInfo[0].split("-")
        cTokens = []

        if tokens[0].isdigit():
            cTokens.append('_')

        for t in tokens:
            cTokens.append(t.capitalize())

        enumEntry = []
        enumEntry.append("".join(cTokens))
        enumEntry.append(f)

        enumConstants.append(enumEntry)


# Generate Icons enum #############################################################################################

print("Generating Icons.cs file...")

if not isdir(outputDirectoryPath):
    mkdir(outputDirectoryPath)

with open(join(outputDirectoryPath, "Icons.cs"), 'w') as enumf:
    enumf.write('namespace Vilma.Blazor.Components\n')
    enumf.write('{\n')
    enumf.write('\n')
    enumf.write('    // This file was generated automatically for the version {bsiversion} of Bootstrap Icons\n'.format(bsiversion = bsiVersion))
    enumf.write("    // Don't modify this file manually and use BSIconExtractor.py tool to regenerate this file.\n")
    enumf.write('\n')
    enumf.write('    public enum Icons\n')
    enumf.write('    {\n')

    for t in enumConstants:
        enumf.write('        ')
        enumf.write(t[0])

        if t  != enumConstants[-1]:
            enumf.write(',')

        enumf.write('\n')

    enumf.write('    }\n')
    enumf.write('}\n')

print("The file Icons.cs was written successfully:")
print("    " + str(len(enumConstants)) + " constants added.")


# Generate SVG container file #####################################################################################

print("Generating SvgIcons.cs file...")

with open(join(outputDirectoryPath, "SvgIcons.cs"), 'w') as extf:
    iconsCtr = 0
    firstPart = '''namespace Vilma.Blazor.Components.Extensions
{{
    internal static partial class Icons
    {{
        // This file was generated automatically for the version {bsiversion} of Bootstrap Icons.
        // Don't modify this file manually and use BSIconExtractor.py tool to regenerate this file.

        private static Dictionary<string, string> s_svgIcons = new Dictionary<string, string>
        {{\n'''

    extf.write(firstPart.format(bsiversion = bsiVersion))

    for f in enumConstants:
        fileInfo = splitext(f[1])

        if fileInfo[1] == '.svg':
            paths = []

            with open(join(pathToSvgFiles, f[1])) as readsvg:
                for line in readsvg.readlines():
                    paths.append(line.strip())

                svgString = "".join(paths)

                entry = '            {{ "{enum}", """{svg}""" }},\n'
                extf.write(entry.format(enum = f[0], svg = svgString))
                iconsCtr += 1


    extf.write('        };\n')
    extf.write('    }\n')
    extf.write('}\n')

    print('The SVG container file SvgIcons.cs was written successfully')
    print('    ' + str(iconsCtr) + ' icons added.')

print('Generation of files was finished successfully!')
