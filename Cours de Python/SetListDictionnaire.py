# Demonstrate list set and dictionnaries

#List peut être modifier à tout va.
List = [0, 1, 2 , 3]
#Set ne peut pas être modifié et ne peut pas avoir de doublon.
Set = {0, 1, 2, 3, 3, 3}
#Ils peuvent avoir une clef et une value
Dictionnaire = {'un':0,'deux':1, 'trois':2, 'quatre':3}

patate = Dictionnaire['deux']

print(patate)

patate = Dictionnaire['deux'] = False

print(patate)

print(Set)
