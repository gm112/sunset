#!/bin/bash


git config core.fsmonitor true
git config feature.manyFiles true
git config pull.rebase true
git config rebase.autoStash true
git lfs install
git lfs pull