#!/bin/bash

export OWNER=BethMassi
export REPO=BethTimeUntil
export BRANCH=master
export URL=https://github.com/$OWNER/$REPO/archive/refs/heads/$BRANCH.zip
curl -v -L -C - -O $URL
mv $BRANCH.zip $OWNER.$REPO.zip
unzip $OWNER.$REPO.zip

export OWNER=iceHub82
export REPO=IceNet.Shared
export BRANCH=master
export URL=https://github.com/$OWNER/$REPO/archive/refs/heads/$BRANCH.zip
curl -v -L -C - -O $URL
mv $BRANCH.zip $OWNER.$REPO.zip
unzip $OWNER.$REPO.zip

export OWNER=Eilon
export REPO=MauiHybridWebView
export BRANCH=main
export URL=https://github.com/$OWNER/$REPO/archive/refs/heads/$BRANCH.zip
curl -v -L -C - -O $URL
mv $BRANCH.zip $OWNER.$REPO.zip
unzip $OWNER.$REPO.zip

export OWNER=Eilon
export REPO=SampleMauiHybridWebViewProject
export BRANCH=main
export URL=https://github.com/$OWNER/$REPO/archive/refs/heads/$BRANCH.zip
curl -v -L -C - -O $URL
mv $BRANCH.zip $OWNER.$REPO.zip
unzip $OWNER.$REPO.zip

export OWNER=BethMassi
export REPO=HybridSharedUI
export BRANCH=master
export URL=https://github.com/$OWNER/$REPO/archive/refs/heads/$BRANCH.zip
curl -v -L -C - -O $URL
mv $BRANCH.zip $OWNER.$REPO.zip
unzip $OWNER.$REPO.zip

export OWNER=kurthildebrand
export REPO=HybridWebView
export BRANCH=main
export URL=https://github.com/$OWNER/$REPO/archive/refs/heads/$BRANCH.zip
curl -v -L -C - -O $URL
mv $BRANCH.zip $OWNER.$REPO.zip
unzip $OWNER.$REPO.zip
