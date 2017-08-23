#!/usr/bin/env python
# 
#  Copyright 2014 Glossom, inc. All rights reserved.
#

import plistlib
import sys

argvs = sys.argv
if argvs.count < 2:
  sys.exit()

file_path = argvs[1]
insert_scheme = argvs[2]

found = False
pl_bunleurltypes = []
pl = plistlib.readPlist(file_path)
if pl.has_key("CFBundleURLTypes"):
  pl_bunleurltypes = pl["CFBundleURLTypes"]
  #check if scheme is already set
  for item in pl["CFBundleURLTypes"]:
    if item.has_key("CFBundleURLSchemes"):
      for scheme in item["CFBundleURLSchemes"]:
        if insert_scheme == scheme:
          found = True
#set url scheme
if not found:
  pl_bunleurltypes.append(dict({'CFBundleURLSchemes' : [insert_scheme]}))  
  pl["CFBundleURLTypes"] = pl_bunleurltypes

plistlib.writePlist(pl, file_path)
